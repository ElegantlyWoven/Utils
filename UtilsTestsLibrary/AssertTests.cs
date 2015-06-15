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
        public void Assert_True()
        {
            Utils.Assert.IsTrue(true, "this is true");

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void Assert_False()
        {
            try
            {
                Utils.Assert.IsTrue(false, "this is false");

                Assert.IsTrue(false);
            }
            catch (Exception aex)
            {
                Assert.IsTrue(aex is Utils.AssertionException);
            }
        }
    }
}
