using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeBuilder.TypeMapping
{
    public class DefaultTypeMapper : ITypeMapper
    {
        public LanguageType GetLanguageType(string database, string language, string dbDataTypeName)
        {
            return new LanguageType();
        }
    }
}
