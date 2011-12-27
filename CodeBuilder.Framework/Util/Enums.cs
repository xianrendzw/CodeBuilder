using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeBuilder.Util
{
    /// <summary>
    /// enumerator of database dbType
    /// </summary>
    public enum Database
    {
        /// <summary>
        /// Microsoft SQL Server 2000
        /// </summary>
        MSSQLServer2000,

        /// <summary>
        /// Microsoft SQL Server 2005
        /// </summary>
        MSSQLServer2005,

        /// <summary>
        /// MySQL 5.0
        /// </summary>
        MySQL5,

        /// <summary>
        /// Oracle8i
        /// </summary>
        Oracle8i,

        /// <summary>
        /// SQLite3
        /// </summary>
        SQLite3
    }

    /// <summary>
    /// enumerator of programming design languages
    /// </summary>
    public enum Language : uint
    {
        /// <summary>
        /// C#
        /// </summary>
        CSharp,

        /// <summary>
        /// JAVA
        /// </summary>
        Java,

        /// <summary>
        /// Ruby
        /// </summary>
        Ruby,
    }
}
