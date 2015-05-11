using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace UtilsTestsLibrary
{
    [TestClass]
    public class AssertTests
    {
        [TestInitialize]
        public void TestInitialize()
        {
            //Utils.Logger.SetLogger(new Utils.DebugLogger());
        }

        [TestMethod]
        public void TestAssertTrue()
        {
            Utils.Assert.IsTrue(true, "this is true");

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestAssertFalse()
        {
            try
            {
                Utils.Assert.IsTrue(false, "this is false");

                Assert.IsTrue(false);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message == "this is false");
            }
        }
    }
}
