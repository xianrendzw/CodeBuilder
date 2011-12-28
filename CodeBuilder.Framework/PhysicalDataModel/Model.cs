using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeBuilder.PhysicalDataModel
{
    /// <summary>
    /// Represent the Physical Data Model of Database.
    /// </summary>
    public class Model
    {
        protected Tables _tables;
        protected Views _views;

        public Model() { }

        public Model(Tables tables)
        {
            this._tables = tables;
        }

        public Model(Views views)
        {
            this._views = views;
        }

        public Model(Tables tables, Views views)
            : this(tables)
        {
            this._views = views;
        }

        public Tables Tables
        {
            get { return this._tables; }
            set { this._tables = value; }
        }

        public Views Views
        {
            get { return this._views; }
            set { this._views = value; }
        }
    }
}
