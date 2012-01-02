using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeBuilder.Exceptions
{
    public class NotFoundPdmDBMSException : Exception
    {
        public NotFoundPdmDBMSException()
            : this("The powerdesigner physical data model(pdm) not specify DBMS.")
        {
        }

        public NotFoundPdmDBMSException(string message)
            : base(message)
        {
        }
    }
}
