using System;

namespace Utils
{
    public class Assert
    {
        static public void IsTrue(Boolean b, String msg, params object[] args)
        {
#if DEBUG
            if (!b)
            {
                String s = String.Format(msg, args);
                Logger.E(s);
                throw new Exception(s);
            }
#endif
        }
    }
}
