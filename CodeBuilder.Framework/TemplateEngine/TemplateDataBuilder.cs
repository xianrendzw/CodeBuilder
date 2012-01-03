using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                        TemplateData templateData = Build(modelObject, settings,  templateName, models[genObject.Key].Database);
                        if (templateData != null) templateDatas.Add(templateData);
                    }
                }
            }

            return templateDatas;
        }

        public static TemplateData Build<T>(T modelObject, GenerationSettings settings, string templateName, string database)
        {
            if (settings == null) return null;

            if (modelObject is Table)
            {
                Table table = modelObject as Table;
                return CreateTemplateData(table, settings, templateName, database);
            }

            if (modelObject is View)
            {
                Table view = modelObject as Table;
                return CreateTemplateData(view, settings, templateName, database);
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
            string templateName, string database) where T : BaseTable, IMetaData
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
            templateData.IsStandardizeName = settings.IsStandardizeName;
            templateData.TemplateFileName = Path.Combine(ConfigManager.TemplatePath,
                ConfigManager.TemplateSection.Templates[templateName].FileName);
            templateData.Name = GetTemplateDataName(settings.IsOmitTablePrefix,
                settings.IsStandardizeName, settings.TablePrefix, modelObject.Name);
            templateData.CodeFileName = PathHelper.GetCodeFileName(ConfigManager.GenerationCodeOuputPath,
                ConfigManager.SettingsSection.Languages[settings.Language].Alias, settings.Package, templateName,
                string.Format("{0}{1}", templateData.Name, ConfigManager.SettingsSection.Languages[settings.Language].Extension));

            modelObject.Name = templateData.Name;
            templateData.ModelObject = GetStandardizedModelObject(modelObject, database, settings);

            return templateData;
        }

        private static string GetTemplateDataName(bool isOmitPrefix, bool isStandardName, string prefix, string name)
        {
            if (isOmitPrefix) name = name.TrimStart(prefix.ToCharArray());
            if (isStandardName) name = name.StandardizeName();
            return name;
        }

        private static T GetStandardizedModelObject<T>(T modelObject,string database,GenerationSettings settings)
            where T : BaseTable, IMetaData
        {
            bool isDynamicLanguage = ConfigManager.SettingsSection.Languages[settings.Language].IsDynamic;
            bool isStandardizeName = settings.IsStandardizeName;
            string languageAlias = ConfigManager.SettingsSection.Languages[settings.Language].Alias;

            if (!isStandardizeName && isDynamicLanguage) return modelObject;

            ITypeMapper typeMapper = null;
            if (!isDynamicLanguage) typeMapper = TypeMapperFactory.Creator();

            foreach (var column in modelObject.Columns.Values)
            {
                if (isStandardizeName) column.Name = column.Name.StandardizeName();
                if (typeMapper != null)
                {
                    LanguageType langType = typeMapper.GetLanguageType(database, languageAlias, column.DataType);
                    if (langType == null) continue;
                    column.LanguageType = langType.TypeName;
                    column.LanguageDefaultValue = langType.DefaultValue;
                }
            }

            return modelObject;
        }

    }
}
