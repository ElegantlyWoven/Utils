using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System;

namespace UtilsTestsLibrary
{
    [TestClass]
    public class LevelLoggerTests
    {
        public LevelLoggerTests()
        {
            _dummylog = new StoreLastMsgLogger();
        }

        [TestMethod]
        public void LevelLogger_D()
        {
            Utils.LevelLogger.SetLogger(_dummylog);

            Utils.LevelLogger.SetLevel(Utils.LevelLogger.Level.INFO);
            Utils.LevelLogger.D("D");

            Assert.IsTrue(_dummylog.LastMessage == "");

            Utils.LevelLogger.SetLevel(Utils.LevelLogger.Level.DEBUG);
            Utils.LevelLogger.D("D");

            Assert.IsTrue(_dummylog.LastMessage == "D D", "Incorrect String");
        }

        [TestMethod]
        public void LevelLogger_I()
        {
            Utils.LevelLogger.SetLogger(_dummylog);

            Utils.LevelLogger.SetLevel(Utils.LevelLogger.Level.WARN);
            Utils.LevelLogger.I("I");

            Assert.IsTrue(_dummylog.LastMessage == "");

            Utils.LevelLogger.SetLevel(Utils.LevelLogger.Level.INFO);
            Utils.LevelLogger.I("I");

            Assert.IsTrue(_dummylog.LastMessage == "I I", "Incorrect String");
        }

        [TestMethod]
        public void LevelLogger_W()
        {
            Utils.LevelLogger.SetLogger(_dummylog);

            Utils.LevelLogger.SetLevel(Utils.LevelLogger.Level.ERROR);
            Utils.LevelLogger.W("W");

            Assert.IsTrue(_dummylog.LastMessage == "");

            Utils.LevelLogger.SetLevel(Utils.LevelLogger.Level.WARN);
            Utils.LevelLogger.W("W");

            Assert.IsTrue(_dummylog.LastMessage == "W W", "Incorrect String");
        }


        [TestMethod]
        public void LevelLogger_E()
        {
            Utils.LevelLogger.SetLogger(_dummylog);

            Utils.LevelLogger.SetLevel(Utils.LevelLogger.Level.ERROR);
            Utils.LevelLogger.E("E");

            Assert.IsTrue(_dummylog.LastMessage == "E E", "Incorrect String");
        }

        [TestMethod]
        public void LevelLogger_X()
        {
            Utils.LevelLogger.SetLogger(_dummylog);

            Utils.LevelLogger.SetLevel(Utils.LevelLogger.Level.ERROR);

            Exception ex = new Exception("Test exception text");

            Utils.LevelLogger.X("Test Message", ex);

            Assert.IsTrue(_dummylog.LastMessage == "E Test Message - System.Exception: 'Test exception text'", "Incorrect String");
        }

        private StoreLastMsgLogger _dummylog;
    }
}
