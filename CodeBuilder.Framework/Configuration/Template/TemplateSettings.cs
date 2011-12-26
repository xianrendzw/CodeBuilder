using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace CodeBuilder.Configuration
{
    [Serializable]
    public class TemplateSettings
    {
        private string _name;
        private string _language;
        private string _engine;
        private string _path;

        public TemplateSettings() { }
        public TemplateSettings(string name, string language, string engine, string path)
        {
            this._name = name;
            this._language = language;
            this._engine = engine;
            this._path = path;
        }

        [XmlAttribute("name")]
        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        [XmlAttribute("language")]
        public string Language
        {
            get { return this._language; }
            set { this._language = value; }
        }

        [XmlAttribute("engine")]
        public string Engine
        {
            get { return this._engine; }
            set { this._engine = value; }
        }

        [XmlAttribute("path")]
        public string Path
        {
            get { return this._path; }
            set { this._path = value; }
        }
    }
}
