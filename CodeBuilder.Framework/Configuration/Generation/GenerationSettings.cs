using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace CodeBuilder.Configuration
{
    [Serializable,
    XmlRoot("GenerationSettings")]
    public class GenerationSettings
    {
        private string _language;
        private string _package;
        private string _tablePrefix;
        private string _author;
        private string _version;
        private string _templateEngine;
        private string[] _templateNames;
        private string _encoding;
        private bool _isOmitTablePrefix;
        private bool _isCamelCaseName;

        public GenerationSettings() { }

        public GenerationSettings(string language, string templateEngine)
        {
            this._language = language;
            this._templateEngine = templateEngine;
        }

        public GenerationSettings(string language, string templateEngine, string package,
            string tablePrefix, string author, string version, string[] templateNames, string encoding,
            bool isOmitTablePrefix, bool isCamelCaseName)
        {
            this._language = language;
            this._templateEngine = templateEngine;
            this._package = package;
            this._tablePrefix = tablePrefix;
            this._author = author;
            this._version = version;
            this._templateNames = templateNames;
            this._encoding = encoding;
            this._isOmitTablePrefix = isOmitTablePrefix;
            this._isCamelCaseName = isCamelCaseName;
        }

        [XmlElement("Language")]
        public string Language
        {
            get { return this._language; }
            set { this._language = value; }
        }

        [XmlElement("Package")]
        public string Package
        {
            get { return this._package ?? string.Empty; }
            set { this._package = value; }
        }

        [XmlElement("TablePrefix")]
        public string TablePrefix
        {
            get { return this._tablePrefix ?? string.Empty; }
            set { this._tablePrefix = value; }
        }

        [XmlElement("Author")]
        public string Author
        {
            get { return this._author ?? string.Empty; }
            set { this._author = value; }
        }

        [XmlElement("Version")]
        public string Version
        {
            get { return this._version ?? string.Empty; }
            set { this._version = value; }
        }

        [XmlElement("TemplateEngine")]
        public string TemplateEngine
        {
            get { return this._templateEngine; }
            set { this._templateEngine = value; }
        }

        [XmlArray("TemplatesNames"), 
        XmlArrayItem("TemplatesName")]
        public string[] TemplatesNames
        {
            get { return this._templateNames; }
            set { this._templateNames = value; }
        }

        [XmlElement("Encoding")]
        public string Encoding
        {
            get { return this._encoding ?? "UTF-8"; }
            set { this._encoding = value; }
        }

        [XmlElement("IsOmitTablePrefix")]
        public bool IsOmitTablePrefix
        {
            get { return this._isOmitTablePrefix; }
            set { this._isOmitTablePrefix = value; }
        }

        [XmlElement("IsCamelCaseName")]
        public bool IsCamelCaseName
        {
            get { return this._isCamelCaseName; }
            set { this._isCamelCaseName = value; }
        }
    }
}
