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
        public void TestParent_AbsFile()
        {
            String filePath = "\\file.typ";

            String parent = Utils.Path.Parent(filePath);

            Assert.IsTrue(parent == "");
        }

        [TestMethod]
        public void TestParent_AbsFolderFile()
        {
            String filePath = "\\folder\\file.typ";

            String parent = Utils.Path.Parent(filePath);

            Assert.IsTrue(parent == "\\folder");
        }

        [TestMethod]
        public void TestParent_AbsFolderFolder()
        {
            String filePath = "\\folder\\subfolder";

            String parent = Utils.Path.Parent(filePath);

            Assert.IsTrue(parent == "\\folder");
        }

        [TestMethod]
        public void TestParent_RelFile()
        {
            String filePath = "file.typ";

            String parent = Utils.Path.Parent(filePath);

            Assert.IsTrue(parent == "");
        }

        [TestMethod]
        public void TestParent_RelFolderFile()
        {
            String filePath = "folder\\file.typ";

            String parent = Utils.Path.Parent(filePath);

            Assert.IsTrue(parent == "folder");
        }

        [TestMethod]
        public void TestParent_RelFolderFolder()
        {
            String filePath = "folder\\subfolder";

            String parent = Utils.Path.Parent(filePath);

            Assert.IsTrue(parent == "folder");
        }

        [TestMethod]
        public void TestParent_Junk()
        {
            String filePath = "blah";

            String parent = Utils.Path.Parent(filePath);

            Assert.IsTrue(parent == "");
        }




        [TestMethod]
        public void TestFileName_AbsFile()
        {
            String filePath = "\\file.typ";

            String parent = Utils.Path.FileName(filePath);

            Assert.IsTrue(parent == "file.typ");
        }

        [TestMethod]
        public void TestFileName_AbsFolderFile()
        {
            String filePath = "\\folder\\file.typ";

            String parent = Utils.Path.FileName(filePath);

            Assert.IsTrue(parent == "file.typ");
        }

        [TestMethod]
        public void TestFileName_AbsFolderFolder()
        {
            String filePath = "\\folder\\subfolder";

            String parent = Utils.Path.FileName(filePath);

            Assert.IsTrue(parent == "subfolder");
        }

        [TestMethod]
        public void TestFileName_RelFile()
        {
            String filePath = "file.typ";

            String parent = Utils.Path.FileName(filePath);

            Assert.IsTrue(parent == "file.typ");
        }

        [TestMethod]
        public void TestFileName_RelFolderFile()
        {
            String filePath = "folder\\file.typ";

            String parent = Utils.Path.FileName(filePath);

            Assert.IsTrue(parent == "file.typ");
        }

        [TestMethod]
        public void TestFileName_RelFolderFolder()
        {
            String filePath = "folder\\subfolder";

            String parent = Utils.Path.FileName(filePath);

            Assert.IsTrue(parent == "subfolder");
        }

        [TestMethod]
        public void TestFileName_Junk()
        {
            String filePath = "blah";

            String parent = Utils.Path.FileName(filePath);

            Assert.IsTrue(parent == "blah");
        }





        [TestMethod]
        public void TestFileType_AbsFile()
        {
            String filePath = "\\file.typ";

            String parent = Utils.Path.FileType(filePath);

            Assert.IsTrue(parent == "typ");
        }

        [TestMethod]
        public void TestFileType_AbsFolderFile()
        {
            String filePath = "\\folder\\file.typ";

            String parent = Utils.Path.FileType(filePath);

            Assert.IsTrue(parent == "typ");
        }

        [TestMethod]
        public void TestFileType_AbsFolderFolder()
        {
            String filePath = "\\folder\\subfolder";

            String parent = Utils.Path.FileType(filePath);

            Assert.IsTrue(parent == "");
        }

        [TestMethod]
        public void TestFileType_RelFile()
        {
            String filePath = "file.typ";

            String parent = Utils.Path.FileType(filePath);

            Assert.IsTrue(parent == "typ");
        }

        [TestMethod]
        public void TestFileType_RelFolderFile()
        {
            String filePath = "folder\\file.typ";

            String parent = Utils.Path.FileType(filePath);

            Assert.IsTrue(parent == "typ");
        }

        [TestMethod]
        public void TestFileType_RelFolderFolder()
        {
            String filePath = "folder\\subfolder";

            String parent = Utils.Path.FileType(filePath);

            Assert.IsTrue(parent == "");
        }

        [TestMethod]
        public void TestFileType_Junk()
        {
            String filePath = "blah";

            String parent = Utils.Path.FileType(filePath);

            Assert.IsTrue(parent == "");
        }





        [TestMethod]
        public void TestNextFolderName_AbsFile()
        {
            String fileName = "\\file.typ";

            int n = 0;
            String name;
            do
            {
                name = Utils.Path.NextFolderName(fileName, n);

                Utils.Logger.D("Name: '{0}'", name);

                Assert.IsTrue(name == "");

                if (name != "")
                {
                    n += name.Length + 2;
                }

            } while (name != "");
        }

        [TestMethod]
        public void TestNextFolderName_AbsFolderFile()
        {
            String fileName = "\\folder\\file.typ";

            int n = 0;
            String name;
            do
            {
                name = Utils.Path.NextFolderName(fileName, n);

                Utils.Logger.D("Name: '{0}'", name);

                Assert.IsTrue((name == "folder") || (name == ""));

                if (name != "")
                {
                    n += name.Length + 1;
                }

            } while (name != "");
        }

        [TestMethod]
        public void TestNextFolderName_AbsFolderFolder()
        {
            String fileName = "\\folder\\subfolder";

            int n = 0;
            String name;
            do
            {
                name = Utils.Path.NextFolderName(fileName, n);

                Utils.Logger.D("Name: '{0}'", name);

                Assert.IsTrue((name == "folder") || (name == "subfolder") || (name == ""));

                if (name != "")
                {
                    n += name.Length + 1;
                }

            } while (name != "");
        }


        [TestMethod]
        public void TestNextFolderName_RelFile()
        {
            String fileName = "file.typ";

            int n = 0;
            String name;
            do
            {
                name = Utils.Path.NextFolderName(fileName, n);

                Utils.Logger.D("Name: '{0}'", name);

                Assert.IsTrue(name == "");

                if (name != "")
                {
                    n += name.Length + 2;
                }

            } while (name != "");
        }

        [TestMethod]
        public void TestNextFolderName_RelFolderFile()
        {
            String fileName = "folder\\file.typ";

            int n = 0;
            String name;
            do
            {
                name = Utils.Path.NextFolderName(fileName, n);

                Utils.Logger.D("Name: '{0}'", name);

                Assert.IsTrue((name == "folder") || (name == ""));

                if (name != "")
                {
                    n += name.Length + 1;
                }

            } while (name != "");
        }

        [TestMethod]
        public void TestNextFolderName_RelFolderFolder()
        {
            String fileName = "folder\\subfolder";

            int n = 0;
            String name;
            do
            {
                name = Utils.Path.NextFolderName(fileName, n);

                Utils.Logger.D("Name: '{0}'", name);

                Assert.IsTrue((name == "folder") || (name == "subfolder") || (name == ""));

                if (name != "")
                {
                    n += name.Length + 1;
                }

            } while (name != "");
        }



        [TestMethod]
        public void TestTrimTrailingSlash_AbsFolderSlash()
        {
            String filePath = "\\folder\\";

            String parent = Utils.Path.TrimTrailingSlash(filePath);

            Assert.IsTrue(parent == "\\folder");
        }

        [TestMethod]
        public void TestTrimTrailingSlash_AbsFolderFolderSlash()
        {
            String filePath = "\\folder\\subfolder\\";

            String parent = Utils.Path.TrimTrailingSlash(filePath);

            Assert.IsTrue(parent == "\\folder\\subfolder");
        }

        [TestMethod]
        public void TestTrimTrailingSlash_AbsFolderNoSlash()
        {
            String filePath = "\\folder";

            String parent = Utils.Path.TrimTrailingSlash(filePath);

            Assert.IsTrue(parent == "\\folder");
        }

        [TestMethod]
        public void TestTrimTrailingSlash_AbsFolderFolderNoSlash()
        {
            String filePath = "\\folder\\subfolder";

            String parent = Utils.Path.TrimTrailingSlash(filePath);

            Assert.IsTrue(parent == "\\folder\\subfolder");
        }


        [TestMethod]
        public void TestTrimTrailingSlash_RelFolderSlash()
        {
            String filePath = "folder\\";

            String parent = Utils.Path.TrimTrailingSlash(filePath);

            Assert.IsTrue(parent == "folder");
        }

        [TestMethod]
        public void TestTrimTrailingSlash_RelFolderFolderSlash()
        {
            String filePath = "folder\\subfolder\\";

            String parent = Utils.Path.TrimTrailingSlash(filePath);

            Assert.IsTrue(parent == "folder\\subfolder");
        }

        [TestMethod]
        public void TestTrimTrailingSlash_RelFolderNoSlash()
        {
            String filePath = "folder";

            String parent = Utils.Path.TrimTrailingSlash(filePath);

            Assert.IsTrue(parent == "folder");
        }

        [TestMethod]
        public void TestTrimTrailingSlash_RelFolderFolderNoSlash()
        {
            String filePath = "folder\\subfolder";

            String parent = Utils.Path.TrimTrailingSlash(filePath);

            Assert.IsTrue(parent == "folder\\subfolder");
        }
    }
}
