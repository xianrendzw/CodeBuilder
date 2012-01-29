using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeBuilder.TypeMapping
{
    using Util;

    public interface ITypeMapper
    {
        LanguageType GetLanguageType(string database, string language, string dbDataTypeName);
    }
}
