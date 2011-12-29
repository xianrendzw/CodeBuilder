using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace CodeBuilder.Configuration
{
    [Serializable, XmlType("Option")]
    public class OptionSettings 
    {
        private string _name;
        private string _value;

        public OptionSettings() { }
        public OptionSettings(string name, string value)
        {
            this._name = name;
            this._value = value;
        }

        [XmlAttribute("name")]
        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        [XmlAttribute("value")]
        public string Value
        {
            get { return this._value; }
            set { this._value = value; }
        }
    }
}
