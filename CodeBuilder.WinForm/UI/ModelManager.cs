using System.Collections.Generic;
using System.Linq;

namespace CodeBuilder.WinForm.UI
{
    using PhysicalDataModel;

    public class ModelManager
    {
        private static Dictionary<string, Model> models = new Dictionary<string, Model>(5);

        public static void Add(string key, Model model)
        {
            if (models.ContainsKey(key))
                models[key] = model;
            else
                models.Add(key, model);
        }

        public static void Clear()
        {
            models.Clear();
        }

        public static bool Remove(string key)
        {
            if (models.ContainsKey(key))
                return models.Remove(key);
            return true;
        }

        public static Dictionary<string, Model> Models
        {
            get { return models; }
        }

        public static string GetDatabase(string key)
        {
            if (models.ContainsKey(key))
                return models[key].Database;
            return string.Empty;
        }

        public static IMetaData GetModelObject(Model model, string objId)
        {
            if (model == null) return null;
            if (model.Tables != null && model.Tables.ContainsKey(objId)) return model.Tables[objId];
            if (model.Views != null && model.Views.ContainsKey(objId)) return model.Views[objId];

            return null;
        }

        public static Dictionary<string, Model> Clone()
        {
            return models.Select(x => x).ToDictionary(y => y.Key, z => z.Value);
        }

        private ModelManager() { }
    }
}
