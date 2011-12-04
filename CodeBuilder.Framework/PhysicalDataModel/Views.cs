using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeBuilder.PhysicalDataModel
{
    /// <summary>
    /// 视图集合类。
    /// </summary>
    public class Views : Dictionary<string, View>
    {
        /// <summary>
        /// 构造函数。
        /// </summary>
        public Views()
            : base()
        {
        }

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="capacity">初始分配的容量数</param>
        public Views(int capacity)
            : base(capacity)
        {
        }
    }
}
