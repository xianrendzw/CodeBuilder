using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeBuilder.Exceptions
{
    public class DatabaseException : ApplicationException
    {
        public DatabaseException(string message)
            :base(message)
        {
        }
    }
}
