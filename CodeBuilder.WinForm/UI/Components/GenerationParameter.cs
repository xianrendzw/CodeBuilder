using System;
using System.Collections.Generic;

namespace CodeBuilder.WinForm.UI
{
    using PhysicalDataModel;
    using Configuration;

    public class GenerationParameter
    {
        private Dictionary<string, Model> _models;
        private Dictionary<string, List<String>> _generationObjects;
        private GenerationSettings _settings;

        public GenerationParameter(Dictionary<string, Model> models,
            Dictionary<string, List<String>> generationObjects,GenerationSettings settings)
        {
            this._models = models;
            this._generationObjects = generationObjects;
            this._settings = settings;
        }

        public Dictionary<string, Model> Models
        {
            get { return this._models; }
        }

        public Dictionary<string, List<String>> GenerationObjects
        {
            get { return this._generationObjects; }
        }

        public GenerationSettings Settings
        {
            get { return this._settings; }
        }
    }
}
