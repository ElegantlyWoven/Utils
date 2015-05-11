using System;
using System.Diagnostics;

namespace Utils
{
    public class WindowsEventLogger : ILogger
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

        /// <summary>
        /// NB Needs admin rights to create source, else throws SecurityException
        /// </summary>
        /// <param name="source"></param>
        /// <param name="logName"></param>
        public WindowsEventLogger(String source, String logName)
        {
            s_strSource = source;

            if (!System.Diagnostics.EventLog.SourceExists(s_strSource))
            {
                System.Diagnostics.EventLog.CreateEventSource(s_strSource, logName);
            }
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

            Debug.WriteLine(str);

            EventLogEntryType t = GetEventLogEntryType(level);

            EventLog.WriteEntry(s_strSource, str, t);
        }

        static private EventLogEntryType GetEventLogEntryType(char level)
        {
            EventLogEntryType t = EventLogEntryType.Information;
            switch (level)
            { 
                case 'W':
                    t = EventLogEntryType.Warning;
                    break;
                case 'E':
                    t = EventLogEntryType.Error;
                    break;
            }
            return t;
        }

        private WindowsEventLogger()
        {
            s_strSource = "";
        }

        static private String s_strSource;

        #endregion
    }
}
