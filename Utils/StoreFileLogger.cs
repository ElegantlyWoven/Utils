using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Windows.Storage;

namespace Utils
{
    public class StoreFileLogger : ILogger, ISuspendable
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
            LogIt('D', "StoreFileLogger.Suspend()");
        }

        public void Resume()
        {
            s_blnContinue = true;
            s_queue = new Queue<String>();
            s_event = new AutoResetEvent(false);
            
            s_task = Task.Factory.StartNew(() => FileLogTask(), TaskCreationOptions.LongRunning);
            
            LogIt('D', "StoreFileLogger.Resume()");
        }

        public StoreFileLogger(String filename)
        {
            s_filename = filename;
            Resume();
        }

        private StoreFileLogger()
        { 
        }

        #region Implementation

        static private void LogIt(char level, String msg, params object[] args)
        {
            Nullable<Int32> threadId = Environment.CurrentManagedThreadId;

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
        static private Task s_task;

        static private async void FileLogTask()
        {
            Debug.WriteLine("FileLogTask START - filename: '{0}'", s_filename);

            StorageFolder folder = ApplicationData.Current.LocalFolder;
            String filename = s_filename + ".txt";
            String backupname = s_filename + ".bak";

            // Backup old file
            // 29/3/15  Must catch FileNotFoundException
            try
            {
                StorageFile f = await folder.GetFileAsync(filename);
                if (f != null)
                {
                    await f.RenameAsync(backupname, NameCollisionOption.ReplaceExisting);
                }
            }
            catch (FileNotFoundException) 
            { }

            // Loop
            try
            {
                StorageFile file = await folder.CreateFileAsync(filename, CreationCollisionOption.FailIfExists);

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

                        Debug.WriteLine(str);

                        List<String> lines = new List<String>();
                        lines.Add(str);
                        await Windows.Storage.FileIO.AppendLinesAsync(file, lines);
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
