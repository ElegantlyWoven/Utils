using System;

namespace Utils
{
    public class Path
    {
        /// <summary>
        /// Returns the parent directory path, or String.Empty if no slash found
        /// </summary>
        /// <param name="child"></param>
        /// <returns></returns>
        public static String Parent(String child)
        {
            String parent = String.Empty;
            int i = child.LastIndexOf("\\");
            if (i > -1)
            {
                parent = child.Substring(0, i);
            }
            return parent;
        }

        /// <summary>
        /// Returns just the file name, or the full string if no slash found
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static String FileName(String path)
        {
            // 28/5/15 Assume it is just a filename
            String file = path;
            int i = path.LastIndexOf("\\");
            if (i > -1)
            {
                file = path.Substring(i + 1);
            }
            return file;
        }

        /// <summary>
        /// Returns just the file extension, or String.Empty
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static String FileType(String path)
        {
            String type = String.Empty;
            int i = path.LastIndexOf(".");
            if (i > -1)
            {
                type = path.Substring(i + 1);
            }
            return type;
        }



        /// <summary>
        /// Splits the given path "[\\]folder\\rest" into "folder" and "\\rest"
        /// Use in a loop on rest until rest == ""
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static void ParsePath(String path, out String folder, out String rest)
        {
            // Handle Abs paths
            if (path[0] == '\\')
            {
                path = path.Substring(1);
            }

            Assert.IsTrue(path[0] != '\\', "NextFolderName() - path arrgh");

            String child = String.Empty;
            int i = path.IndexOf("\\");
            if (i > -1)
            {
                folder = path.Substring(0, i);
                rest = path.Substring(i);
            }
            else
            {
                folder = path;
                rest = "";
            }
        }

        /// <summary>
        /// Returns the string without the final slash, or just the final string as is
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static String TrimTrailingSlash(String path)
        {
            String p1 = path;
            if (p1.Length > 0)
            {
                int i1 = p1.LastIndexOf("\\");
                if (i1 == p1.Length - 1)
                {
                    p1 = p1.Substring(0, i1);
                }
            }
            return p1;
        }
    }
}
