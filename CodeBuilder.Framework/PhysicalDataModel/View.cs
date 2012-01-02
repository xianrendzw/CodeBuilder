using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeBuilder.PhysicalDataModel
{
    public class View : BaseTable
    {
        public View()
            : this("", "", "")
        {
        }

        public View(string id, string displayName, string name)
            : this(id, displayName, name,string.Empty)
        {
        }

        public View(string id, string displayName, string name, string comment)
            : base(id, displayName, name, comment)
        {
            this._mataTypeName = "view";
        }
    }
}
