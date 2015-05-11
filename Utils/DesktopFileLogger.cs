using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
#if DOTNET45
using System.Threading.Tasks;
#endif

namespace Utils
{
    public class DesktopFileLogger : ILogger, ISuspendable
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

        public void Suspend()
        {
            s_blnContinue = false;
            LogIt('D', "DesktopFileLogger.Suspend()");
        }

        public void Resume()
        {
            s_blnContinue = true;
            s_queue = new Queue<String>();
            s_event = new AutoResetEvent(false);            

#if DOTNET45
            s_task = Task.Factory.StartNew(() => FileLogTask(), TaskCreationOptions.LongRunning);
#else
            s_thread = new Thread(new ThreadStart(FileLogTask));
            s_thread.Start();
#endif

            LogIt('D', "DesktopFileLogger.Resume()");
        }

        public DesktopFileLogger(String filename)
        {
            s_filename = filename;
            Resume();
        }

        private DesktopFileLogger()
        {
        }

        #region Implementation

        static private void LogIt(char level, String msg, params object[] args)
        {
#if DOTNET45
            Nullable<Int32> threadId = Environment.CurrentManagedThreadId;
#else
            Nullable<Int32> threadId = Thread.CurrentThread.GetHashCode();
#endif
            String str = LogMessage.Format(DateTime.Now, threadId, level, msg, args);

            lock (s_queue)
            {
                s_queue.Enqueue(str);
            }
            s_event.Set();
        }

        static private String s_filename;
        static private Queue<String> s_queue;
        static private AutoResetEvent s_event;
        static private Boolean s_blnContinue;
#if DOTNET45
        static private Task s_task;
#else
        static private Thread s_thread;
#endif

        static private void FileLogTask()
        {
            Debug.WriteLine(String.Format("FileLogTask START - filename: '{0}'", s_filename));

            // Full path or place in home area
            String file;
            if ((s_filename.Length > 1) && (s_filename[1] == ':'))
            {
                file = s_filename;
            }
            else
            {
                String HOME = Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%");
                file = HOME + "\\" + s_filename;
            }

            // Delete old backup
            // 24/3/15  Prevent throw
            String backup = file + ".bak";
            if (File.Exists(backup))
            {
                File.Delete(backup);
            }

            // Backup old file
            // 24/3/15  Prevent throw
            if (File.Exists(file))
            {
                File.Move(file, backup);
            }

            // Loop
            try
            {
                while (s_event.WaitOne())
                {
                    while (s_queue.Count > 0)
                    {
                        String str = null;
                        lock (s_queue)
                        {
                            str = s_queue.Dequeue();
                        }
                        Assert.IsTrue(str != null, "FileLogTask() - got null from queue");

                        using (StreamWriter sw = new StreamWriter(file, true))
                        {
                            Debug.WriteLine(str);

                            sw.WriteLine(str);
                            sw.Flush();
                        }
                    }

                    if (!s_blnContinue)
                        break;
                }
            }
            catch (IOException ioe)
            {
                Debug.WriteLine(ioe.Message);
            }
             
            Debug.WriteLine("FileLogTask END");
        }

        #endregion
    }
}
