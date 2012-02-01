using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeBuilder.Exceptions
{
    using Framework.Properties;

    public class NotSupportDatabaseException : Exception
    {
        public NotSupportDatabaseException()
            : this(Resource.NotSupportDatabaseExceptionMessage)
        {
        }

        public NotSupportDatabaseException(string message)
            : base(message)
        {
        }
    }
}
