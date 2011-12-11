using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace CodeBuilder.Util.Test
{
    public class LoggerTest
    {
        private static Logger logger;

        [SetUp]
        public void Setup()
        {
            logger = InternalTrace.GetLogger(typeof(LoggerTest));
        }

        [Test]
        public void Is_Not_Null()
        {
            Assert.That(logger, Is.Not.Null);
        }

        [Test]
        public void Is_Writer_Logs()
        {
            logger.Info("Info");
            logger.Error("Error");
        }

        [TearDown]
        public void Down()
        {
            logger = null;
        }
    }
}
