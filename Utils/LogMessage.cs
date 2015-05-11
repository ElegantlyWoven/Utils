using System;

namespace Utils
{
    public static class LogMessage
    {
        public static String Format(DateTime dt, Nullable<Int32> threadId, char level, String msg, params object[] args)
        {
            String timestamp = dt.ToString("HH:mm:ss.fffff");
            String message = String.Format(msg, args);

            String str = String.Format("{0}: {1}: {2}: {3}", timestamp, level, threadId, message);
            return str;
        }
    }
}
