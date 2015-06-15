using System;

namespace Utils
{
    public static class Assert
    {
        // Release mode too
        static public void IsTrue(Boolean b, String msg, params object[] args)
        {
            if (!b)
            {
                String s = String.Format(msg, args);
                Logger.E(s);
                throw new AssertionException(s);
            }
        }
    }

    // Throw a specific exception
    public class AssertionException : Exception
    {
        public AssertionException(String s) :
            base(s)
        {
        }
    }
}
