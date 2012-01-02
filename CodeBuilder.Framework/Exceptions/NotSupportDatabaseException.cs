using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeBuilder.Exceptions
{
    public class NotSupportDatabaseException : Exception
    {
        public NotSupportDatabaseException()
            : this("Sorry!CodeBuilder not support this database.")
        {
        }

        public NotSupportDatabaseException(string message)
            : base(message)
        {
        }
    }
}
