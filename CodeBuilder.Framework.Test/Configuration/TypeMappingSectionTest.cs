using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using NUnit.Framework;

namespace CodeBuilder.Configuration.Test
{
    [Category("Configuration")]
    public class TypeMappingSectionTest
    {
        private TypeMappingSection section;

        [SetUp]
        public void Setup()
        {
            this.section = (TypeMappingSection)ConfigurationManager.GetSection("codebuilder.typemapping");
        }

        [Test]
        public void Is_Not_Null()
        {
            Assert.That(this.section, Is.Not.Null);
        }

        [Test]
        public void Should_Return_Corrected_Values()
        {
            Assert.That(2, Is.EqualTo(this.section.TypeMappings.Count));
            Assert.That("sqlserver2005-csharp", Is.EqualTo(this.section.TypeMappings[0].Name));
            Assert.That("sqlserver2005", Is.EqualTo(this.section.TypeMappings[0].Database));
            Assert.That("csharp", Is.EqualTo(this.section.TypeMappings[0].Langauge));
            Assert.That(1, Is.EqualTo(this.section.TypeMappings[0].Types.Count));
        }

        [TearDown]
        public void Down()
        {
            this.section = null;
        }
    }
}
