using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace CodeBuilder.CLI
{
    using Configuration;

    class Program
    {
        static void Main(string[] args)
        {
            TypeMappingSection section = (TypeMappingSection)ConfigurationManager.GetSection("codebuilder/typeMapping");
            Console.WriteLine(section.Mappings.Count);
            Console.WriteLine("Ok");
            Console.Read();
        }
    }
}
