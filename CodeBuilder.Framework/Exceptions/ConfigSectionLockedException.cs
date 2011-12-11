using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeBuilder.Exceptions
{
    public class ConfigSectionLockedException: Exception
    {
        public ConfigSectionLockedException()
            :this("配置节被锁定。")
        {
        }

        public ConfigSectionLockedException(string message)
            :base(message)
        {
        }
    }
}
