using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeBuilder.PhysicalDataModel
{
    public class Columns : Dictionary<string,Column>
    {
        public Columns()
            : base()
        {
        }

        public Columns(int capacity)
            : base(capacity)
        {
        }
    }
}
