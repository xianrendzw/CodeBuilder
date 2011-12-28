using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace CodeBuilder.CLI
{
    using Configuration;
    using Util;

    class Program
    {
        static void Main(string[] args)
        {
            //TypeMappingSection section = (TypeMappingSection)ConfigurationManager.GetSection("codebuilder/typeMapping");
            //Console.WriteLine(section.Mappings.Count);

            //InternalTrace.Initialize("Test.txt",InternalTraceLevel.Info);
            //Logger logger = InternalTrace.GetLogger(typeof(Program));
            //logger.Error("Ok");

            DataSourceSettingsList list = new DataSourceSettingsList(10);
            for (int i = 0; i < 10; i++)
            {
                list.Add(new DataSourceSettings()
                {
                    ConnectionString = "connect" + i.ToString(),
                    Name = "Name" + i.ToString(),
                    Exporter = "PowerDesigner12"
                });
            }

            SerializeHelper.XmlSerialize(list, @"e:\ds.xml");

            Console.WriteLine("Ok");
            Console.Read();
        }
    }
}
