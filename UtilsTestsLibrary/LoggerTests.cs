using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System;

namespace UtilsTestsLibrary
{
    [TestClass]
    public class LoggerTests
    {
        public LoggerTests()
        {
            _dummylog = new StoreLastMsgLogger();
        }

        [TestMethod]
        public void TestLogD()
        {
            Utils.Logger.SetLogger(_dummylog);

            Utils.Logger.D("D");

            Assert.IsTrue(_dummylog.LastMessage == "D D", "Incorrect String");
        }

        [TestMethod]
        public void TestLogI()
        {
            Utils.Logger.SetLogger(_dummylog);

            Utils.Logger.I("I");

            Assert.IsTrue(_dummylog.LastMessage == "I I", "Incorrect String");
        }

        [TestMethod]
        public void TestLogW()
        {
            Utils.Logger.SetLogger(_dummylog);

            Utils.Logger.W("W");

            Assert.IsTrue(_dummylog.LastMessage == "W W", "Incorrect String");
        }

        [TestMethod]
        public void TestLogE()
        {
            Utils.Logger.SetLogger(_dummylog);

            Utils.Logger.E("E");

            Assert.IsTrue(_dummylog.LastMessage == "E E", "Incorrect String");
        }

        [TestMethod]
        public void TestLogX()
        {
            Utils.Logger.SetLogger(_dummylog);

            Exception ex = new Exception("Test exception text");

            Utils.Logger.X("Test Message", ex);

            Assert.IsTrue(_dummylog.LastMessage == "E Test Message - System.Exception: 'Test exception text'", "Incorrect String");
        }

        [TestMethod]
        public void TestLogX4()
        {
            Utils.Logger.SetLogger(_dummylog);

            Exception ex4 = new Exception("Inner exception text 4");
            Exception ex3 = new Exception("Inner exception text 3", ex4);
            Exception ex2 = new Exception("Inner exception text 2", ex3);
            Exception ex1 = new Exception("Inner exception text 1", ex2);
            Exception ex = new Exception("Test exception text", ex1);

            Utils.Logger.X("Test Message", ex);

            Assert.IsTrue(_dummylog.LastMessage == "E Test Message - InnerException: 'Inner exception text 4'", "Incorrect String");
        }

        [TestMethod]
        public void TestLogX5()
        {
            Utils.Logger.SetLogger(_dummylog);

            Exception ex5 = new Exception("Inner exception text 5");
            Exception ex4 = new Exception("Inner exception text 4", ex5);
            Exception ex3 = new Exception("Inner exception text 3", ex4);
            Exception ex2 = new Exception("Inner exception text 2", ex3);
            Exception ex1 = new Exception("Inner exception text 1", ex2);
            Exception ex = new Exception("Test exception text", ex1);

            Utils.Logger.X("Test Message", ex);

            Assert.IsTrue(_dummylog.LastMessage == "E Test Message - InnerException: 'Inner exception text 4'", "Incorrect String");
        }

        [TestMethod]
        public void TestLogSuspendAndResume()
        {
            Utils.Logger.SetLogger(_dummylog);

            Assert.IsTrue(_dummylog.Running, "Should be running at start");

            Utils.Logger.Suspend();
            Assert.IsTrue(!_dummylog.Running, "Suspend didn't");

            Utils.Logger.Resume();
            Assert.IsTrue(_dummylog.Running, "Resume didn't");
        }

        private StoreLastMsgLogger _dummylog;


#if false
        [TestMethod]
        public void TestLevelD()
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
        public void TestLevelI()
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
        public void TestLevelW()
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
        public void TestLevelE()
        {
            Utils.LevelLogger.SetLogger(_dummylog);

            Utils.LevelLogger.SetLevel(Utils.LevelLogger.Level.ERROR);
            Utils.LevelLogger.E("E");

            Assert.IsTrue(_dummylog.LastMessage == "E E", "Incorrect String");
        }

        [TestMethod]
        public void TestLevelX()
        {
            Utils.LevelLogger.SetLogger(_dummylog);

            Utils.LevelLogger.SetLevel(Utils.LevelLogger.Level.ERROR);

            Exception ex = new Exception("Test exception text");

            Utils.LevelLogger.X("Test Message", ex);

            Assert.IsTrue(_dummylog.LastMessage == "E Test Message - System.Exception: 'Test exception text'", "Incorrect String");
        }
#endif
    }
}
