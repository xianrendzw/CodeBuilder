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

        public static IMetaData GetModelObject(Model model, string objId)
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
            templateData.Name = modelObject.Name;
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
            templateData.TemplateFileName = ConfigManager.TemplateSection.Templates[templateName].FileName;
            templateData.CodeFileName = Path.Combine(ConfigManager.GenerationCodeOuputPath,settings.Package,
                ConfigManager.SettingsSection.Languages[settings.Language].Alias,
                string.Format("{0}{1}", templateData.Name, ConfigManager.SettingsSection.Languages[settings.Language].Extension));
            templateData.ModelObject = modelObject;

            return templateData;

            //LanguageType langType = TypeMapperFactory.Creator().GetLanguageType(
            //    this._config.Database,
            //    this._config.Value, dataTypeName);
            //column.LanguageType = langType.TypeName;
            //column.LanguageDefaultValue = langType.DefaultValue;
        }

        private static string StandardizeName(string name)
        {
            return string.Empty;
        }

        public static string OmitPrefix(string prefix)
        {
            return string.Empty;
        }
    }
}
