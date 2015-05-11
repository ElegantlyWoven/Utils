using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace UtilsTestsLibrary
{
    static public class Log
    {
        static public void D(string msg, params object[] args)
        {
            _logger.D(msg, args);
        }

        static public void I(string msg, params object[] args)
        {
            _logger.I(msg, args);
        }

        static public void W(string msg, params object[] args)
        {
            _logger.W(msg, args);
        }

        static public void E(string msg, params object[] args)
        {
            _logger.E(msg, args);
        }

        static public void SetLogger(ILog impl)
        {
            _logger = impl;
        }

        static private ILog _logger;
    }
}
