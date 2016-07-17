using System;
using System.Collections.Generic;
using System.IO;

namespace CodeBuilder.TemplateEngine
{
    using Configuration;
    using PhysicalDataModel;
    using TypeMapping;
    using Util;

    public class TemplateDataBuilder
    {
        public static List<TemplateData> Build(Dictionary<string, Model> models,
            Dictionary<string, List<String>> generationObjects, GenerationSettings settings)
        {
            List<TemplateData> templateDatas = new List<TemplateData>();
            foreach (var genObject in generationObjects)
            {
                foreach (string objId in genObject.Value)
                {
                    IMetaData modelObject = GetModelObject(models[genObject.Key], objId);
                    if (modelObject == null) continue;

                    foreach (string templateName in settings.TemplatesNames)
                    {
                        TemplateData templateData = Build(modelObject, settings, templateName, 
                            models[genObject.Key].Database, genObject.Key);
                        if (templateData != null) templateDatas.Add(templateData);
                    }
                }
            }

            return templateDatas;
        }

        public static TemplateData Build<T>(T modelObject, GenerationSettings settings, 
            string templateName, string database,string modelId)
        {
            if (settings == null) return null;

            if (modelObject is Table)
            {
                Table table = modelObject as Table;
                return CreateTemplateData(table, settings, templateName, database, modelId);
            }

            if (modelObject is View)
            {
                View view = modelObject as View;
                return CreateTemplateData(view, settings, templateName, database, modelId);
            }

            return null;
        }

        private static IMetaData GetModelObject(Model model, string objId)
        {
            if (model == null) return null;
            if (model.Tables != null && model.Tables.ContainsKey(objId)) return model.Tables[objId];
            if (model.Views != null && model.Views.ContainsKey(objId)) return model.Views[objId];

            return null;
        }

        private static TemplateData CreateTemplateData<T>(T modelObject, GenerationSettings settings,
            string templateName, string database, string modelId) where T : BaseTable, IMetaData
        {
            TemplateData templateData = new TemplateData();
            templateData.Database = database;
            templateData.TemplateName = templateName;
            templateData.Author = settings.Author;
            templateData.Version = settings.Version;
            templateData.Language = settings.Language;
            templateData.Package = settings.Package;
            templateData.TablePrefix = settings.TablePrefix;
            templateData.TemplateEngine = settings.TemplateEngine;
            templateData.Encoding = settings.Encoding;
            templateData.IsOmitTablePrefix = settings.IsOmitTablePrefix;
            templateData.IsCamelCaseName = settings.IsCamelCaseName;
            templateData.Prefix = ConfigManager.TemplateSection.Templates[templateName].Prefix;
            templateData.Suffix = ConfigManager.TemplateSection.Templates[templateName].Suffix;
            templateData.Name = GetTemplateDataName(settings.IsOmitTablePrefix,
               settings.IsCamelCaseName, settings.TablePrefix, modelObject.OriginalName);

            templateData.TemplateFileName = Path.Combine(ConfigManager.TemplatePath,
                ConfigManager.TemplateSection.Templates[templateName].FileName);
            string fileName = string.Format("{0}{1}{2}", templateData.Prefix, templateData.Name, templateData.Suffix);
            templateData.CodeFileName = string.Format("{0}{1}", PathHelper.GetCodeFileName(ConfigManager.GenerationCodeOuputPath,
                ConfigManager.SettingsSection.Languages[settings.Language].Alias,
                ConfigManager.SettingsSection.TemplateEngines[settings.TemplateEngine].Name,
                ConfigManager.TemplateSection.Templates[templateName].DisplayName, settings.Package, modelId, fileName),
                ConfigManager.SettingsSection.Languages[settings.Language].Extension);

            modelObject.Name = templateData.Name;
            templateData.ModelObject = GetCamelCaseModelObject(modelObject, database, settings);

            return templateData;
        }

        private static string GetTemplateDataName(bool isOmitPrefix, bool isCamelCaseName, string tablePrefix, string name)
        {
            if (isOmitPrefix && (tablePrefix ?? "").Length > 0) name = name.Replace(tablePrefix, "");
            if (isCamelCaseName) name = name.CamelCaseName();
            return name;
        }

        private static T GetCamelCaseModelObject<T>(T modelObject,string database,GenerationSettings settings)
            where T : BaseTable, IMetaData
        {
            bool isCamelCaseName = settings.IsCamelCaseName;
            bool isDynamicLanguage = ConfigManager.SettingsSection.Languages[settings.Language].IsDynamic;
            string languageAlias = ConfigManager.SettingsSection.Languages[settings.Language].Alias;

            if (!isCamelCaseName && isDynamicLanguage) return modelObject;

            ITypeMapper typeMapper = null;
            if (!isDynamicLanguage) typeMapper = TypeMapperFactory.Creator();
            string typeMappingDatabase = ConfigManager.SettingsSection.Databases[database].TypeMapping;

            foreach (var column in modelObject.Columns.Values)
            {
                if (isCamelCaseName) column.Name = column.OriginalName.CamelCaseName();
                if (typeMapper != null)
                {
                    LanguageType langType = typeMapper.GetLanguageType(typeMappingDatabase, languageAlias, column.DataType);
                    if (langType == null) continue;
                    column.LanguageType = langType.TypeName;
                    column.LanguageDefaultValue = string.IsNullOrEmpty(column.DefaultValue) ? langType.DefaultValue : column.DefaultValue;
                }
            }

            return modelObject;
        }
    }
}
