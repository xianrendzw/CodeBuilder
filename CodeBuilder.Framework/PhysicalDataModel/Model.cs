using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeBuilder.PhysicalDataModel
{
    /// <summary>
    /// 表示数据库中物理数据模型的类。
    /// </summary>
    public class Model
    {
        protected Tables _tables;
        protected Views _views;

        /// <summary>
        /// 构造函数。
        /// </summary>
        public Model() { }

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param typeName="tables">数据模型中表对象集合</param>
        public Model(Tables tables)
        {
            this._tables = tables;
        }

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param typeName="views">数据模型中视图对象集合</param>
        public Model(Views views)
        {
            this._views = views;
        }

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param typeName="tables">数据模型中表对象集合</param>
        /// <param typeName="views">数据模型中视图对象集合</param>
        public Model(Tables tables, Views views)
            : this(tables)
        {
            this._views = views;
        }

        /// <summary>
        /// 获取或设置数据模型中的表对象集合。
        /// </summary>
        public Tables Tables
        {
            get { return this._tables; }
            set { this._tables = value; }
        }

        /// <summary>
        ///  获取或设置数据模型中的视图对象集合。
        /// </summary>
        public Views Views
        {
            get { return this._views; }
            set { this._views = value; }
        }
    }
}
