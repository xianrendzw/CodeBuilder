using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeBuilder.PhysicalDataModel
{
    public class Column
    {
        protected string _id;
        protected string _name;
        protected string _code;
        protected string _standardCode;
        protected string _comment;
        protected string _dataType;
        protected string _defaultValue;
        protected string _languageType = "String";
        protected string _languageDefaultValue = string.Empty;
        protected int _length;
        protected int _ordinal = -1;
        protected bool _isAutoIncremented;
        protected bool _isNullable;
        protected bool _hasDefault;
        protected bool _isComputed;
       

        /// <summary>
        /// 构造函数。
        /// </summary>
        public Column()
        {
        }

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="id">列的唯一标识名称</param>
        /// <param name="name">列的友好名称</param>
        /// <param name="code">列的名称(建议用英文字母表示)</param>
        public Column(string id, string name, string code)
        {
            this._id = id;
            this._name = name;
            this._code = code;
        }

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="id">列的唯一标识名称</param>
        /// <param name="name">列的友好名称</param>
        /// <param name="code">列的名称(建议用英文字母表示)</param>
        /// <param name="dataType">列的数据类型(如:int,char,datetime等)</param>
        public Column(string id, string name, string code, string dataType)
            : this(id, name, code)
        {
            this._dataType = dataType;
        }

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="id">列的唯一标识名称</param>
        /// <param name="name">列的友好名称</param>
        /// <param name="code">列的名称(建议用英文字母表示)</param>
        /// <param name="dataType">列的数据类型(如:int,char,datetime等)</param>
        /// <param name="comment">列的说明或注释</param>
        public Column(string id, string name, string code, string dataType, string comment)
            : this(id, name, code, dataType)
        {
            this._comment = comment;
        }

        /// <summary>
        /// 获取或设置列的唯一标识名称。
        /// </summary>
        public string Id
        {
            get { return this._id; }
            set { this._id = value; }
        }

        /// <summary>
        /// 获取或设置列的友好名称。
        /// </summary>
        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        /// <summary>
        /// 获取或设置列的名称(建议用英文字母表示)。
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
        /// 获取或设置列的说明或注释。
        /// </summary>
        public string Comment
        {
            get { return this._comment; }
            set { this._comment = value; }
        }

        /// <summary>
        /// 获取或设置列的数据类型(如:int,char,datetime等)。
        /// </summary>
        public string DataType
        {
            get { return this._dataType; }
            set { this._dataType = value; }
        }

        /// <summary>
        /// 获取或设置列的数据类型占用字节长度。
        /// </summary>
        public int Length
        {
            get { return this._length; }
            set { this._length = value; }
        }

        /// <summary>
        /// 获取或设置列是否为数据库中的自增列。
        /// </summary>
        public bool IsAutoIncremented
        {
            get { return this._isAutoIncremented; }
            set { this._isAutoIncremented = value; }
        }

        /// <summary>
        /// 获取或设置列的值是否不能为空。
        /// </summary>
        public bool IsNullable
        {
            get { return this._isNullable; }
            set { this._isNullable = value; }
        }

        /// <summary>
        /// 获取或设置列的默认值。
        /// </summary>
        public string DefaultValue
        {
            get { return this._defaultValue; }
            set { this._defaultValue = value; }
        }

        /// <summary>
        /// 获取或设置列数据类型对应的程序设计语言(CSharp,Java)数据类型。
        /// </summary>
        public string LanguageType
        {
            get { return this._languageType; }
            set { this._languageType = value; }
        }

        /// <summary>
        /// 获取或设置列的模型默认值对应的程序设计语言(CSharp,Java)默认值。
        /// </summary>
        public string LanguageDefaultValue
        {
            get { return this._languageDefaultValue; }
            set { this._languageDefaultValue = value; }
        }

        /// <summary>
        /// 获取或设置列的在表中的顺序。
        /// </summary>
        public int Ordinal
        {
            get { return this._ordinal; }
            set { this._ordinal = value; }
        }

        /// <summary>
        /// 获取或设置列是否有默认值。
        /// </summary>
        public bool HasDefault
        {
            get { return this._hasDefault; }
            set { this._hasDefault = value; }
        }

        /// <summary>
        /// 获取或设置列是否为计算列。
        /// </summary>
        public bool IsComputed
        {
            get { return this._isComputed; }
            set { this._isComputed = value; }
        }
    }
}
