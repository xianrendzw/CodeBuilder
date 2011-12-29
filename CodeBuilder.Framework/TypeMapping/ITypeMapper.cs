using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeBuilder.TypeMapping
{
    using Util;

    public interface ITypeMapper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param typeName="database"></param>
        /// <param typeName="value"></param>
        /// <param typeName="dbDataTypeName"></param>
        /// <returns></returns>
        LanguageType GetLanguageType(string database, string language, string dbDataTypeName);
    }
}
