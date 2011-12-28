using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace CodeBuilder.Configuration
{
    [Serializable, XmlType("Template")]
    public class TemplateSettings
    {
        private string _name;
        private string _language;
        private string _engine;
        private string _path;
        private string _url;
        private string _description;

        public TemplateSettings() { }
        public TemplateSettings(string name, string language, string engine)
        {
            this._name = name;
            this._language = language;
            this._engine = engine;
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

        [XmlAttribute("url")]
        public string Url
        {
            get { return this._url; }
            set { this._url = value; }
        }

        [XmlAttribute("desc")]
        public string Description
        {
            get { return this._description; }
            set { this._description = value; }
        }
    }
}
