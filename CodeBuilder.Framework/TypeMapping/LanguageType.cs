using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeBuilder.TypeMapping
{
    /// <summary>
    /// programming design value's data dbType.(such as int|string|bool|double| etc.)
    /// </summary>
    public class LanguageType
    {
        private string _typeName;
        private string _defaultValue;
        private string _alias;

        public LanguageType(string typeName, string defaultValue,string alias)
        {
            this._typeName = typeName;
            this._defaultValue = defaultValue;
            this._alias = alias;
        }

        public string TypeName
        {
            get { return this._typeName; }
            set { this._typeName = value; }
        }

        public string DefaultValue
        {
            get { return this._defaultValue; }
            set { this._defaultValue = value; }
        }

        public string Alias
        {
            get { return this._alias; }
            set { this._alias = value; }
        }
    }
}
