using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace UtilsTestsLibrary
{
    [TestClass]
    public class LogTests
    {
        public LogTests()
        {
            _dummylog = new StoreLastLog();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            Utils.Log.SetLogger(_dummylog);
        }

        [TestMethod]
        public void TestLogD()
        {
            Utils.Log.D("D");

            Assert.IsTrue(_dummylog.LastMessage() == "D D", "Incorrect string");
        }

        [TestMethod]
        public void TestLogI()
        {
            Utils.Log.I("I");

            Assert.IsTrue(_dummylog.LastMessage() == "I I", "Incorrect string");
        }

        [TestMethod]
        public void TestLogW()
        {
            Utils.Log.W("W");

            Assert.IsTrue(_dummylog.LastMessage() == "W W", "Incorrect string");
        }

        [TestMethod]
        public void TestLogE()
        {
            Utils.Log.E("E");

            Assert.IsTrue(_dummylog.LastMessage() == "E E", "Incorrect string");
        }

        private StoreLastLog _dummylog;
    }
}
