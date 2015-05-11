using System;

namespace Utils
{
    public class Path
    {
        /// <summary>
        /// Returns the parent directory path or null
        /// </summary>
        /// <param name="child"></param>
        /// <returns></returns>
        public static String Parent(String child)
        {
            String parent = child;
            int i = parent.LastIndexOf("\\");
            if (i > -1)
            {
                parent = parent.Substring(0, i);
                return parent;
            }
            return null;
        }

        /// <summary>
        /// Returns just the file name
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static String FileName(String path)
        {
            int i = path.LastIndexOf("\\");
            if (i > -1)
            {
                String file = path.Substring(i + 1);
                return file;
            }
            return null;
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
        /// 
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
