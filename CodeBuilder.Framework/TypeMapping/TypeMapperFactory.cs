using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeBuilder.TypeMapping
{
    public class TypeMapperFactory
    {
        private static ITypeMapper instance;

        public static ITypeMapper Creator()
        {
            instance = new DefaultTypeMapper();
            return instance;
        }
    }
}
