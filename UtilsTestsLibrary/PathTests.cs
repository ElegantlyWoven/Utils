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
        public void Parent_AbsFile()
        {
            String filePath = "\\file.typ";

            String parent = Utils.Path.Parent(filePath);

            Assert.IsTrue(parent == "");
        }

        [TestMethod]
        public void Parent_AbsFolderFile()
        {
            String filePath = "\\folder\\file.typ";

            String parent = Utils.Path.Parent(filePath);

            Assert.IsTrue(parent == "\\folder");
        }

        [TestMethod]
        public void Parent_AbsFolderFolder()
        {
            String filePath = "\\folder\\subfolder";

            String parent = Utils.Path.Parent(filePath);

            Assert.IsTrue(parent == "\\folder");
        }

        [TestMethod]
        public void Parent_RelFile()
        {
            String filePath = "file.typ";

            String parent = Utils.Path.Parent(filePath);

            Assert.IsTrue(parent == "");
        }

        [TestMethod]
        public void Parent_RelFolderFile()
        {
            String filePath = "folder\\file.typ";

            String parent = Utils.Path.Parent(filePath);

            Assert.IsTrue(parent == "folder");
        }

        [TestMethod]
        public void Parent_RelFolderFolder()
        {
            String filePath = "folder\\subfolder";

            String parent = Utils.Path.Parent(filePath);

            Assert.IsTrue(parent == "folder");
        }

        [TestMethod]
        public void Parent_Junk()
        {
            String filePath = "blah";

            String parent = Utils.Path.Parent(filePath);

            Assert.IsTrue(parent == "");
        }




        [TestMethod]
        public void FileName_AbsFile()
        {
            String filePath = "\\file.typ";

            String parent = Utils.Path.FileName(filePath);

            Assert.IsTrue(parent == "file.typ");
        }

        [TestMethod]
        public void FileName_AbsFolderFile()
        {
            String filePath = "\\folder\\file.typ";

            String parent = Utils.Path.FileName(filePath);

            Assert.IsTrue(parent == "file.typ");
        }

        [TestMethod]
        public void FileName_AbsFolderFolder()
        {
            String filePath = "\\folder\\subfolder";

            String parent = Utils.Path.FileName(filePath);

            Assert.IsTrue(parent == "subfolder");
        }

        [TestMethod]
        public void FileName_RelFile()
        {
            String filePath = "file.typ";

            String parent = Utils.Path.FileName(filePath);

            Assert.IsTrue(parent == "file.typ");
        }

        [TestMethod]
        public void FileName_RelFolderFile()
        {
            String filePath = "folder\\file.typ";

            String parent = Utils.Path.FileName(filePath);

            Assert.IsTrue(parent == "file.typ");
        }

        [TestMethod]
        public void FileName_RelFolderFolder()
        {
            String filePath = "folder\\subfolder";

            String parent = Utils.Path.FileName(filePath);

            Assert.IsTrue(parent == "subfolder");
        }

        [TestMethod]
        public void FileName_Junk()
        {
            String filePath = "blah";

            String parent = Utils.Path.FileName(filePath);

            Assert.IsTrue(parent == "blah");
        }





        [TestMethod]
        public void FileType_AbsFile()
        {
            String filePath = "\\file.typ";

            String parent = Utils.Path.FileType(filePath);

            Assert.IsTrue(parent == "typ");
        }

        [TestMethod]
        public void FileType_AbsFolderFile()
        {
            String filePath = "\\folder\\file.typ";

            String parent = Utils.Path.FileType(filePath);

            Assert.IsTrue(parent == "typ");
        }

        [TestMethod]
        public void FileType_AbsFolderFolder()
        {
            String filePath = "\\folder\\subfolder";

            String parent = Utils.Path.FileType(filePath);

            Assert.IsTrue(parent == "");
        }

        [TestMethod]
        public void FileType_RelFile()
        {
            String filePath = "file.typ";

            String parent = Utils.Path.FileType(filePath);

            Assert.IsTrue(parent == "typ");
        }

        [TestMethod]
        public void FileType_RelFolderFile()
        {
            String filePath = "folder\\file.typ";

            String parent = Utils.Path.FileType(filePath);

            Assert.IsTrue(parent == "typ");
        }

        [TestMethod]
        public void FileType_RelFolderFolder()
        {
            String filePath = "folder\\subfolder";

            String parent = Utils.Path.FileType(filePath);

            Assert.IsTrue(parent == "");
        }

        [TestMethod]
        public void FileType_Junk()
        {
            String filePath = "blah";

            String parent = Utils.Path.FileType(filePath);

            Assert.IsTrue(parent == "");
        }



        [TestMethod]
        public void ParsePath_AbsFile()
        {
            String fileName = "\\file.typ";

            String current = fileName;
            String folder;
            String rest;
            do
            {
                Utils.Path.ParsePath(current, out folder, out rest);

                Utils.Logger.D("folder: '{0}', rest: '{1}'", folder, rest);

                Assert.IsTrue(folder == "file.typ");
                Assert.IsTrue(rest == "");

                if (rest != "")
                {
                    current = rest;
                }
            } while (rest != "");
        }

        [TestMethod]
        public void ParsePath_AbsFolderFile()
        {
            String fileName = "\\folder\\file.typ";

            String current = fileName;
            String folder;
            String rest;
            do
            {
                Utils.Path.ParsePath(current, out folder, out rest);

                Utils.Logger.D("folder: '{0}', rest: '{1}'", folder, rest);

                Assert.IsTrue((folder == "folder" && rest == "\\file.typ") ||
                                (folder == "file.typ" && rest == ""));

                if (rest != "")
                {
                    current = rest;
                }
            } while (rest != "");
        }

        [TestMethod]
        public void ParsePath_AbsFolderFolder()
        {
            String fileName = "\\folder\\subfolder";

            String current = fileName;
            String folder;
            String rest;
            do
            {
                Utils.Path.ParsePath(current, out folder, out rest);

                Utils.Logger.D("folder: '{0}', rest: '{1}'", folder, rest);

                Assert.IsTrue((folder == "folder" && rest == "\\subfolder") ||
                                (folder == "subfolder" && rest == ""));

                if (rest != "")
                {
                    current = rest;
                }
            } while (rest != "");
        }


        [TestMethod]
        public void ParsePath_RelFile()
        {
            String fileName = "file.typ";

            String current = fileName;
            String folder;
            String rest;
            do
            {
                Utils.Path.ParsePath(current, out folder, out rest);

                Utils.Logger.D("folder: '{0}', rest: '{1}'", folder, rest);

                Assert.IsTrue(folder == "file.typ");
                Assert.IsTrue(rest == "");

                if (rest != "")
                {
                    current = rest;
                }
            } while (rest != "");
        }

        [TestMethod]
        public void ParsePath_RelFolderFile()
        {
            String fileName = "folder\\file.typ";

            String current = fileName;
            String folder;
            String rest;
            do
            {
                Utils.Path.ParsePath(current, out folder, out rest);

                Utils.Logger.D("folder: '{0}', rest: '{1}'", folder, rest);

                Assert.IsTrue((folder == "folder" && rest == "\\file.typ") ||
                                (folder == "file.typ" && rest == ""));

                if (rest != "")
                {
                    current = rest;
                }
            } while (rest != "");
        }

        [TestMethod]
        public void ParsePath_RelFolderFolder()
        {
            String fileName = "folder\\subfolder";

            String current = fileName;
            String folder;
            String rest;
            do
            {
                Utils.Path.ParsePath(current, out folder, out rest);

                Utils.Logger.D("folder: '{0}', rest: '{1}'", folder, rest);

                Assert.IsTrue((folder == "folder" && rest == "\\subfolder") ||
                                 (folder == "subfolder" && rest == ""));

                if (rest != "")
                {
                    current = rest;
                }
            } while (rest != "");
        }



        /// <summary>
        /// TestTrimTrailingSlash
        /// </summary>

        [TestMethod]
        public void TrimTrailingSlash_AbsFolderSlash()
        {
            String filePath = "\\folder\\";

            String parent = Utils.Path.TrimTrailingSlash(filePath);

            Assert.IsTrue(parent == "\\folder");
        }

        [TestMethod]
        public void TrimTrailingSlash_AbsFolderFolderSlash()
        {
            String filePath = "\\folder\\subfolder\\";

            String parent = Utils.Path.TrimTrailingSlash(filePath);

            Assert.IsTrue(parent == "\\folder\\subfolder");
        }

        [TestMethod]
        public void TrimTrailingSlash_AbsFolderNoSlash()
        {
            String filePath = "\\folder";

            String parent = Utils.Path.TrimTrailingSlash(filePath);

            Assert.IsTrue(parent == "\\folder");
        }

        [TestMethod]
        public void TrimTrailingSlash_AbsFolderFolderNoSlash()
        {
            String filePath = "\\folder\\subfolder";

            String parent = Utils.Path.TrimTrailingSlash(filePath);

            Assert.IsTrue(parent == "\\folder\\subfolder");
        }


        [TestMethod]
        public void TrimTrailingSlash_RelFolderSlash()
        {
            String filePath = "folder\\";

            String parent = Utils.Path.TrimTrailingSlash(filePath);

            Assert.IsTrue(parent == "folder");
        }

        [TestMethod]
        public void TrimTrailingSlash_RelFolderFolderSlash()
        {
            String filePath = "folder\\subfolder\\";

            String parent = Utils.Path.TrimTrailingSlash(filePath);

            Assert.IsTrue(parent == "folder\\subfolder");
        }

        [TestMethod]
        public void TrimTrailingSlash_RelFolderNoSlash()
        {
            String filePath = "folder";

            String parent = Utils.Path.TrimTrailingSlash(filePath);

            Assert.IsTrue(parent == "folder");
        }

        [TestMethod]
        public void TrimTrailingSlash_RelFolderFolderNoSlash()
        {
            String filePath = "folder\\subfolder";

            String parent = Utils.Path.TrimTrailingSlash(filePath);

            Assert.IsTrue(parent == "folder\\subfolder");
        }
    }
}
