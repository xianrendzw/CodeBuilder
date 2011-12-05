using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeBuilder.Util
{
    /// <summary>
    /// 数据库枚举
    /// </summary>
    public enum Database : uint
    {
        /// <summary>
        /// Microsoft SQL Server 2000
        /// </summary>
        MSSQLServer2000 = 1,

        /// <summary>
        /// Microsoft SQL Server 2005
        /// </summary>
        MSSQLServer2005 = 2,

        /// <summary>
        /// MySQL 5.0
        /// </summary>
        MySQL5 = 3,

        /// <summary>
        /// Oracle8i
        /// </summary>
        Oracle8i = 4,

        /// <summary>
        /// SQLite2
        /// </summary>
        SQLite2 = 5,

        /// <summary>
        /// SQLite3
        /// </summary>
        SQLite3 = 6
    }

    /// <summary>
    /// 程序设计语言枚举
    /// </summary>
    public enum Language : uint
    {
        /// <summary>
        /// C#程序设计语言
        /// </summary>
        CSharp = 1,

        /// <summary>
        /// JAVA程序设计语言
        /// </summary>
        Java = 2,

        /// <summary>
        /// Ruby程序设计语言
        /// </summary>
        Ruby = 3,
    }
}
