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
        public void TestSettingNoFile()
        {
            Utils.SimpleXmlConfigFile settings = new Utils.SimpleXmlConfigFile("nonesuch.xml");

            String value = settings.GetConfigEntry("section", "name");
            Assert.IsTrue(value == null, "Unexpected value found: '{0}'", value);
        }

        [TestMethod]
        public void TestSettingNoSection()
        {
            Utils.SimpleXmlConfigFile settings = new Utils.SimpleXmlConfigFile("Settings.xml");

            String value = settings.GetConfigEntry("nonesuch", "nonesuch");
            Assert.IsTrue(value == null, "Unexpected value found: '{0}'", value);
        }

        [TestMethod]
        public void TestSettingNoEntry()
        {
            Utils.SimpleXmlConfigFile settings = new Utils.SimpleXmlConfigFile("Settings.xml");

            String value = settings.GetConfigEntry("section", "nonesuch");
            Assert.IsTrue(value == null, "Unexpected value found: '{0}'", value);
        }

        [TestMethod]
        public void TestSettingWithEntry()
        {
            Utils.SimpleXmlConfigFile settings = new Utils.SimpleXmlConfigFile("Settings.xml");

            String value = settings.GetConfigEntry("section", "entry");
            Assert.IsTrue(value != null, "Expected value NOT found");
        }
    }
}
