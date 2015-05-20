using System;

namespace Utils
{
    /// <summary>
    /// Simple static logger.
    /// </summary>
    static public class Logger
    {
        static public void D(String msg, params object[] args)
        {
            s_logger.D(msg, args);
        }

        static public void I(String msg, params object[] args)
        {
            s_logger.I(msg, args);
        }

        static public void W(String msg, params object[] args)
        {
            s_logger.W(msg, args);
        }

        static public void E(String msg, params object[] args)
        {
            s_logger.E(msg, args);
        }

        static public void X(String msg, Exception ex)
        {
            s_logger.E("{0} - {1}: '{2}'", msg, ex.GetType(), ex.Message);

            // 5/2/15 Max loop
            int n = 0;
            while (((ex = ex.InnerException) != null) && (++n < 5))
            {
                s_logger.E("{0} - InnerException: '{1}'", msg, ex.Message);
            }
        }

        static public void Suspend()
        {
            ISuspendable isl = s_logger as ISuspendable;
            if (isl != null)
            {
                isl.Suspend();
            }
        }

        static public void Resume()
        {
            ISuspendable isl = s_logger as ISuspendable;
            if (isl != null)
            {
                isl.Resume();
            }
        }

        static public void SetLogger(ILogger impl)
        {
            if (impl == null) { throw new NullReferenceException("SetLogger() - null is not allowed"); }
              
            s_logger.D("SetLogger() - '{0}', is ISuspendable: {1}", impl.GetType(), (impl is ISuspendable));
            s_logger = impl;
        }

        static Logger()
        {
        }

        static private ILogger s_logger = new DebugLogger();
    }


#if false
        /// <summary>
        /// Example method for reading app.config appSettings
        /// </summary>
        static public ILogger GetConfiguredLogger()
        {
            ILogger il = new DebugLogger();

            try
            {
                String logger = ConfigurationManager.AppSettings["LoggerClass"];
                if (logger != null)
                {
                    if (logger.Equals("DesktopFileLogger"))
                    {
                        String file = ConfigurationManager.AppSettings["File"];
                        il = new DesktopFileLogger(file);
                    }
                    else if (logger.Equals("WindowsEventLogger"))
                    {
                        String source = ConfigurationManager.AppSettings["Source"];
                        String name = ConfigurationManager.AppSettings["Name"];
                        il = new WindowsEventLogger(source, name);
                    }
                    else if (logger.Equals("TraceLogger"))
                    {
                        il = new TraceLogger();
                    }
                }
            }
            catch (ConfigurationErrorsException cee)
            {
            }

            return il;
        }
#endif
}
