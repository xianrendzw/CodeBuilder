using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeBuilder.Util
{
    /// <summary>
    /// enumerator of database type
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
    /// enumerator of programming design languages
    /// </summary>
    public enum Language : uint
    {
        /// <summary>
        /// C#
        /// </summary>
        CSharp = 1,

        /// <summary>
        /// JAVA
        /// </summary>
        Java = 2,

        /// <summary>
        /// Ruby
        /// </summary>
        Ruby = 3,
    }
}
