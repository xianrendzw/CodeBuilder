using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeBuilder.Exceptions
{
    using Framework.Properties;

    public class NotFoundPdmDBMSException : Exception
    {
        public NotFoundPdmDBMSException()
            : this(Resource.NotFoundPdmDBMSExceptionMessage)
        {
        }

        public NotFoundPdmDBMSException(string message)
            : base(message)
        {
        }
    }
}
