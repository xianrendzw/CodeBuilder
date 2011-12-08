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
            this.section = (TypeMappingSection)ConfigurationManager.GetSection("codebuilder/typeMapping");
        }

        [Test]
        public void Is_Not_Null()
        {
            Assert.That(this.section, Is.Not.Null);
        }

        [Test]
        public void Should_Return_Corrected_Values()
        {
            Assert.That(this.section.Mappings.Count, Is.EqualTo(4));
            Assert.That(this.section.Mappings[0].Name, Is.EqualTo("sqlserver2005-csharp"));
            Assert.That(this.section.Mappings[0].Database, Is.EqualTo("sqlserver2005"));
            Assert.That(this.section.Mappings[0].Language, Is.EqualTo("csharp"));
            Assert.That(this.section.Mappings[0].Types.Count, Is.EqualTo(25));
        }

        [TearDown]
        public void Down()
        {
            this.section = null;
        }
    }
}
