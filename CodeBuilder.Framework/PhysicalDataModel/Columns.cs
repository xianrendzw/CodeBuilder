using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeBuilder.PhysicalDataModel
{
    /// <summary>
    /// 列集合类。
    /// </summary>
    public class Columns : Dictionary<string,Column>
    {
        /// <summary>
        /// 构造函数。
        /// </summary>
        public Columns()
            : base()
        {
        }

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="capacity">初始分配的容量数</param>
        public Columns(int capacity)
            : base(capacity)
        {
        }
    }
}
