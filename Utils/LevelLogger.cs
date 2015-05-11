using System;

namespace Utils
{
    /// <summary>
    /// More complex static logger.
    /// </summary>
    static public class LevelLogger
    {
        static public void D(String msg, params object[] args)
        {
            if (s_level > Level.INFO)
            {
                s_logger.D(msg, args);
            }
        }

        static public void I(String msg, params object[] args)
        {
            if (s_level > Level.WARN)
            {
                s_logger.I(msg, args);
            }
        }

        static public void W(String msg, params object[] args)
        {
            if (s_level > Level.ERROR)
            {
                s_logger.W(msg, args);
            }
        }

        static public void E(String msg, params object[] args)
        {
            if (s_level > Level.NONE)
            {
                s_logger.E(msg, args);
            }
        }

        static public void X(String msg, Exception ex)
        {
            if (s_level > Level.NONE)
            {
                s_logger.E("{0} - {1}: '{2}'", msg, ex.GetType(), ex.Message);

                // 5/2/15 Max loop
                int n = 0;
                while (((ex = ex.InnerException) != null) && (++n < 5))
                {
                    s_logger.E("{0} - InnerException: '{1}'", msg, ex.Message);
                }
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

        /// <summary>
        /// 
        /// </summary>
        static public void SetLogger(ILogger impl)
        {
            if (impl == null) { throw new NullReferenceException("SetLogger() - null is not allowed"); }

            s_logger.D("SetLogger() - '{0}', is ISuspendable: {1}", impl.GetType(), (impl is ISuspendable));
            s_logger = impl;
        }

        public enum Level { NONE = 0, ERROR = 1, WARN = 2, INFO = 3, DEBUG = 4 };

        static public void SetLevel(Level level)
        {
            s_level = level;
        }

        static LevelLogger()
        {
        }

        static private ILogger s_logger = new DebugLogger();
        static private Level s_level = Level.DEBUG;
    }
}
