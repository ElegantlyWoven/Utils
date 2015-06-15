using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilsTestsLibrary
{
    [TestClass]
    public class SimpleXmlConfigFileTests
    {
        [TestMethod]
        public void SimpleXmlConfigFile_NoFile()
        {
            Utils.SimpleXmlConfigFile settings = new Utils.SimpleXmlConfigFile("nonesuch.xml");

            String value = settings.GetConfigEntry("section", "name");
            Assert.IsTrue(value == null, "Unexpected value found: '{0}'", value);
        }

        [TestMethod]
        public void SimpleXmlConfigFile_NoSection()
        {
            Utils.SimpleXmlConfigFile settings = new Utils.SimpleXmlConfigFile("Settings.xml");

            String value = settings.GetConfigEntry("nonesuch", "nonesuch");
            Assert.IsTrue(value == null, "Unexpected value found: '{0}'", value);
        }

        [TestMethod]
        public void SimpleXmlConfigFile_NoEntry()
        {
            Utils.SimpleXmlConfigFile settings = new Utils.SimpleXmlConfigFile("Settings.xml");

            String value = settings.GetConfigEntry("section", "nonesuch");
            Assert.IsTrue(value == null, "Unexpected value found: '{0}'", value);
        }

        [TestMethod]
        public void SimpleXmlConfigFile_WithEntry()
        {
            Utils.SimpleXmlConfigFile settings = new Utils.SimpleXmlConfigFile("Settings.xml");

            String value = settings.GetConfigEntry("section", "entry");
            Assert.IsTrue(value != null, "Expected value NOT found");
        }
    }
}
