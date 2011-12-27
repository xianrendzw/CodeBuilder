using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeBuilder.PhysicalDataModel
{
    /// <summary>
    /// 表集合类。
    /// </summary>
    public class Tables : Dictionary<string, Table>
    {
        /// <summary>
        /// 构造函数。
        /// </summary>
        public Tables()
            : base()
        {
        }

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param typeName="capacity">初始分配的容量数</param>
        public Tables(int capacity)
            : base(capacity)
        {
        }
    }
}
