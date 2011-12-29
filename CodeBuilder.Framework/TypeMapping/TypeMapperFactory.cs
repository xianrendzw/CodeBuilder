using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeBuilder.TypeMapping
{
    using Configuration;

    public class TypeMapperFactory
    {
        private static ITypeMapper instance;

        public static ITypeMapper Creator()
        {
            if (instance == null)
            {
                string typeName = ConfigManager.SettingsSection.AppSettings["typeMapper"].Value;
                instance = (ITypeMapper)Activator.CreateInstance(Type.GetType(typeName));
            }

            return instance;
        }
    }
}
