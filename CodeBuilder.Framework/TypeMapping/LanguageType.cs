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

        public LanguageType(string typeName, string defaultValue)
        {
            this._typeName = typeName;
            this._defaultValue = defaultValue;
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
    }
}
