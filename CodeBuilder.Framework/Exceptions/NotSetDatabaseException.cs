using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeBuilder.Exceptions
{
    public class NotSetDatabaseException : Exception
    {
        public NotSetDatabaseException()
            : this("The powerdesigner physical data model(pdm) not specify DBMS.")
        {
        }

        public NotSetDatabaseException(string message)
            : base(message)
        {
        }
    }
}
