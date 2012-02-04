using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace CodeBuilder.Configuration
{
    public sealed class TemplateElement : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true)]
        public String Name
        {
            get { return base["name"].ToString().ToLower(); }
            set { base["name"] = value; }
        }

        [ConfigurationProperty("displayName", IsRequired = true)]
        public String DisplayName
        {
            get { return base["displayName"].ToString(); }
            set { base["displayName"] = value; }
        }

        [ConfigurationProperty("language", IsRequired = true)]
        public string Language
        {
            get { return base["language"].ToString(); }
            set { base["language"] = value; }
        }

        [ConfigurationProperty("engine", IsRequired = true)]
        public string Engine
        {
            get { return base["engine"].ToString(); }
            set { base["engine"] = value; }
        }

        [ConfigurationProperty("fileName", IsRequired = true)]
        public string FileName
        {
            get { return base["fileName"].ToString(); }
            set { base["fileName"] = value; }
        }

        [ConfigurationProperty("prefix", IsRequired = true)]
        public string Prefix
        {
            get { return base["prefix"].ToString(); }
            set { base["prefix"] = value; }
        }

        [ConfigurationProperty("suffix", IsRequired = true)]
        public string Suffix
        {
            get { return base["suffix"].ToString(); }
            set { base["suffix"] = value; }
        }

        [ConfigurationProperty("url", IsRequired = true)]
        public string Url
        {
            get { return base["url"].ToString(); }
            set { base["url"] = value; }
        }

        [ConfigurationProperty("desc", IsRequired = true)]
        public string Description
        {
            get { return base["desc"].ToString(); }
            set { base["desc"] = value; }
        }

        [ConfigurationProperty("category", IsRequired = true)]
        public string Category
        {
            get { return base["category"].ToString(); }
            set { base["category"] = value; }
        }

        [ConfigurationProperty("version", IsRequired = true)]
        public string Version
        {
            get { return base["version"].ToString(); }
            set { base["version"] = value; }
        }

        [ConfigurationProperty("parser", IsRequired = false)]
        public string Parser
        {
            get { return base["parser"].ToString(); }
            set { base["parser"] = value; }
        }
    }
}
