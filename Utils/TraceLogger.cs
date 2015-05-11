using System;
using System.Diagnostics;

namespace Utils
{
    public class TraceLogger : ILogger
    {
        public void D(String msg, params object[] args)
        {
            LogIt('D', msg, args);
        }

        public void I(String msg, params object[] args)
        {
            LogIt('I', msg, args);
        }

        public void W(String msg, params object[] args)
        {
            LogIt('W', msg, args);
        }

        public void E(String msg, params object[] args)
        {
            LogIt('E', msg, args);
        }

        #region Implementation

        static private void LogIt(char level, String msg, params object[] args)
        {
#if DOTNET45
            Nullable<Int32> threadId = Environment.CurrentManagedThreadId;
#else
            Nullable<Int32> threadId = System.Threading.Thread.CurrentThread.GetHashCode();
#endif
            String str = LogMessage.Format(DateTime.Now, threadId, level, msg, args);

            // Debug.WriteLine(str);

            switch (level)
            {
                case 'E':
                    Trace.TraceError(str);
                    break;
                case 'W':
                    Trace.TraceWarning(str);
                    break;
                case 'I':
                    Trace.TraceInformation(str);
                    break;
                case 'D':
                    Trace.WriteLine(str);
                    break;
                default:
                    Assert.IsTrue(false, "TraceLogger.LogIt() - Invalid log level: '{0}'", level);
                    break;
            }
        }

        #endregion
    }
}
