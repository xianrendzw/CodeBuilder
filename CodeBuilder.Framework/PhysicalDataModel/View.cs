using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeBuilder.PhysicalDataModel
{
    /// <summary>
    /// 数据模型的视图类
    /// </summary>
    public class View
    {
        protected string _id;
        protected string _name;
        protected string _code;
        protected string _standardCode;
        protected string _comment;
        protected Columns _columns;

        /// <summary>
        /// 构造函数。
        /// </summary>
        public View()
        {
        }

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="id">视图的唯一标识名称</param>
        /// <param name="name">视图的友好名称</param>
        /// <param name="code">视图的名称(建议用英文字母表示)</param>
        public View(string id, string name, string code)
            : this(id, name, code, string.Empty)
        {
        }

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="id">视图的唯一标识名称</param>
        /// <param name="name">视图的友好名称</param>
        /// <param name="code">视图的名称(建议用英文字母表示)</param>
        /// <param name="comment">视图的说明或注释。</param>
        public View(string id, string name, string code, string comment)
        {
            this._id = id;
            this._name = name;
            this._code = code;
            this._comment = comment;
        }

        /// <summary>
        /// 获取或设置视图的唯一标识名称。
        /// </summary>
        public string Id
        {
            get { return this._id; }
            set { this._id = value; }
        }

        /// <summary>
        /// 获取或设置视图的友好名称。
        /// </summary>
        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        /// <summary>
        /// 获取或设置视图的名称(建议用英文字母表示)。
        /// </summary>
        public string Code
        {
            get { return this._code; }
            set { this._code = value; }
        }

        /// <summary>
        /// 获取或设置列的标准名称(采用CamelCase命名风格,如:Name,TypeName)
        /// </summary>
        public string StandardCode
        {
            get { return this._standardCode; }
            set { this._standardCode = value; }
        }

        /// <summary>
        /// 获取或设置视图的说明或注释。
        /// </summary>
        public string Comment
        {
            get { return this._comment; }
            set { this._comment = value; }
        }

        /// <summary>
        /// 获取或设置视图的列集合。
        /// </summary>
        public Columns Columns
        {
            get { return this._columns; }
            set { this._columns = value; }
        }
    }
}
