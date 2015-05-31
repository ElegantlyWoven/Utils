using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace UtilsTestsLibrary
{
    [TestClass]
    public class PathTests
    {
        [TestInitialize]
        public void TestInitialize()
        {
            //Utils.Logger.SetLogger(new Utils.DebugLogger());
        }

        [TestMethod]
        public void TestFolderNameFile()
        {
            String fileName = "file.typ";

            int n = 0;
            String name;
            do
            {
                name = Utils.Path.FolderName(fileName, n);

                Utils.Logger.D("Name: '{0}'", name);

                if (name != "")
                {
                    n += name.Length + 2;
                }

            } while (name != "");
        }

        [TestMethod]
        public void TestFolderNameFolderFile()
        {
            String fileName = "root\\file.typ";

            int n = 0;
            String name;
            do
            {
                name = Utils.Path.FolderName(fileName, n);

                Utils.Logger.D("Name: '{0}'", name);

                if (name != "")
                {
                    n += name.Length + 1;
                }

            } while (name != "");
        }

        [TestMethod]
        public void TestFolderNameFolderFolderFile()
        {
            String fileName = "root\\folder\\file.typ";

            int n = 0;
            String name;
            do
            {
                name = Utils.Path.FolderName(fileName, n);

                Utils.Logger.D("Name: '{0}'", name);

                if (name != "")
                {
                    n += name.Length + 1;
                }

            } while (name != "");
        }

    }
}
