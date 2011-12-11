using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeBuilder.Exceptions
{
    public class NotSetDatabaseException : Exception
    {
        public NotSetDatabaseException()
            : this("模型中未指定数据库系统类型,请指定一个数据库系统类型。")
        {
        }

        public NotSetDatabaseException(string message)
            : base(message)
        {
        }
    }
}
