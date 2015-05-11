using System;

namespace UtilsTestsLibrary
{
    class StoreLastLog : Utils.ILog
    {
        void Utils.ILog.D(string msg, params object[] args)
        {
            StoreIt('D', msg, args);
        }

        void Utils.ILog.I(string msg, params object[] args)
        {
            StoreIt('I', msg, args);
        }

        void Utils.ILog.W(string msg, params object[] args)
        {
            StoreIt('W', msg, args);
        }

        void Utils.ILog.E(string msg, params object[] args)
        {
            StoreIt('E', msg, args);
        }


        public string LastMessage()
        {
            return _strLast;
        }

        private void StoreIt(char level, string msg, params object[] args)
        {
            string message = String.Format(msg, args);

            _strLast = String.Format("{0} {1}", level, message);
        }

        private string _strLast;
    }
}
