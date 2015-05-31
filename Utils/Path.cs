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
        /// Returns the next folder name starting at index, or String.Empty
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static String NextFolderName(String path, int startIndex)
        {
            Assert.IsTrue(path.StartsWith("\\"), "NextFolderName() - path arrgh");

            String folder = String.Empty;
            int i = path.IndexOf("\\", startIndex);
            if (i > -1)
            {
                folder = path.Substring(startIndex, i - startIndex);
            }
            return folder;
        }


        /// <summary>
        /// Returns true if the paths are the same
        /// </summary>
        /// <param name="path1"></param>
        /// <param name="path2"></param>
        /// <returns></returns>
        public static Boolean Equals(String path1, String path2)
        {
            return TrimTrailingSlash(path1) == TrimTrailingSlash(path2);
        }

        /// <summary>
        /// Returns the string without the final slash, or the final string
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
