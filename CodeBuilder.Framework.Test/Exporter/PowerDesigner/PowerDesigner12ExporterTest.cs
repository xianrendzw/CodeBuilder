using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace CodeBuilder.DataSource.Exporter.PowerDesigner.Test
{
    using PowerDesigner;
    using PhysicalDataModel;

    [Category("Exporter")]
    public class PowerDesigner12ExporterTest
    {
        private IExporter exporter;

        [SetUp]
        public void Setup()
        {
            this.exporter = new PowerDesigner12Exporter();
        }

        [Test]
        public void Is_Exporter_Not_Null()
        {
            Assert.That(this.exporter, Is.Not.Null);
        }

        [Test]
        public void Export_Model_From_PowerdesignerFile()
        {
            string connstr = AppDomain.CurrentDomain.BaseDirectory + @"\test.pdm";
            Model model = this.exporter.Export(connstr);

            Assert.That(model,Is.Not.Null);
            Assert.That(model.Tables.Count, Is.EqualTo(5));
            Assert.That(model.Views, Is.Null);
        }

        [TearDown]
        public void Down()
        {
            this.exporter = null;
        }
    }
}
