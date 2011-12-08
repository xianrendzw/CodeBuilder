using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeBuilder.TypeMapping
{
    /// <summary>
    /// programming design language's data type.(such as int|string|bool|double| etc.)
    /// </summary>
    public class LanguageType
    {
        public string TypeName { get; set; }
        public string DefaultValue { get; set; }
    }
}
