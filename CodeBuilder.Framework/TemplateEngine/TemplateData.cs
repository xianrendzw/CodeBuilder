using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeBuilder.TemplateEngine
{
    using Util;
    using Configuration;
    using PhysicalDataModel;

    public class TemplateData
    {
        private string _name;
        private string _language;
        private string _database;
        private string _package;
        private string _tablePrefix;
        private string _author;
        private string _version;
        private string _templateEngine;
        private string _templateName;
        private string _prefix;
        private string _suffix;
        private string _encoding;
        private string _templateFileName;
        private string _codeFileName;
        private bool _isOmitTablePrefix;
        private bool _isCamelCaseName;
        private object _modelObject;

        public TemplateData() { }

        public TemplateData(string name, string language, string database, string templateEngine, string package,
            string tablePrefix, string author, string version, string templateName, string prefix, string suffix,
            string encoding, string templateFileName, string codeFileName, bool isOmitTablePrefix, bool isCamelCaseName, object modelObject)
        {
            this._name = name;
            this._language = language;
            this._database = database;
            this._templateEngine = templateEngine;
            this._package = package;
            this._tablePrefix = tablePrefix;
            this._author = author;
            this._version = version;
            this._templateName = templateName;
            this._prefix = prefix;
            this._suffix = suffix;
            this._encoding = encoding;
            this._templateFileName = templateFileName;
            this._codeFileName = codeFileName;
            this._isOmitTablePrefix = isOmitTablePrefix;
            this._isCamelCaseName = isCamelCaseName;
            this._modelObject = modelObject;
        }

        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        public string Language
        {
            get { return this._language; }
            set { this._language = value; }
        }

        public string Database
        {
            get { return this._database; }
            set { this._database = value; }
        }

        public string Package
        {
            get { return this._package ?? string.Empty; }
            set { this._package = value; }
        }

        public string TablePrefix
        {
            get { return this._tablePrefix ?? string.Empty; }
            set { this._tablePrefix = value; }
        }

        public string Author
        {
            get { return this._author ?? string.Empty; }
            set { this._author = value; }
        }

        public string Version
        {
            get { return this._version ?? string.Empty; }
            set { this._version = value; }
        }

        public string TemplateEngine
        {
            get { return this._templateEngine; }
            set { this._templateEngine = value; }
        }

        public string TemplateName
        {
            get { return this._templateName; }
            set { this._templateName = value; }
        }

        public string Prefix
        {
            get { return this._prefix ?? string.Empty; }
            set { this._prefix = value; }
        }

        public string Suffix
        {
            get { return this._suffix ?? string.Empty; }
            set { this._suffix = value; }
        }

        public string Encoding
        {
            get { return this._encoding ?? "UTF-8"; }
            set { this._encoding = value; }
        }

        public string TemplateFileName
        {
            get { return this._templateFileName; }
            set { this._templateFileName = value; }
        }

        public string CodeFileName
        {
            get { return this._codeFileName; }
            set { this._codeFileName = value; }
        }

        public bool IsOmitTablePrefix
        {
            get { return this._isOmitTablePrefix; }
            set { this._isOmitTablePrefix = value; }
        }

        public bool IsCamelCaseName
        {
            get { return this._isCamelCaseName; }
            set { this._isCamelCaseName = value; }
        }

        public object ModelObject
        {
            get { return this._modelObject; }
            set { this._modelObject = value; }
        }
    }
}
