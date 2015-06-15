using System;

namespace Utils
{
    // Release mode too
    public static class Assert
    {
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

    // A specific exception
    public class AssertionException : Exception
    {
        public AssertionException(String s) :
            base(s)
        {
        }
    }
}
