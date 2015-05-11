using System;

namespace UtilsTestsLibrary
{
    class StoreLastMsgLogger : Utils.ILogger, Utils.ISuspendable
    {
        public void D(String msg, params object[] args)
        {
            StoreIt('D', msg, args);
        }

        public void I(String msg, params object[] args)
        {
            StoreIt('I', msg, args);
        }

        public void W(String msg, params object[] args)
        {
            StoreIt('W', msg, args);
        }

        public void E(String msg, params object[] args)
        {
            StoreIt('E', msg, args);
        }

        public void Suspend() 
        { 
            _running = false; 
        }

        public void Resume() 
        { 
            _running = true; 
        }

        public String LastMessage 
        {            
            get { return _strLast; }
        }

        public Boolean Running 
        { 
            get { return _running; } 
        }

        public StoreLastMsgLogger()
        {
            _strLast = "";
            _running = true;
        }

        #region Implementation

        private void StoreIt(char level, String msg, params object[] args)
        {
            String message = String.Format(msg, args);

            _strLast = String.Format("{0} {1}", level, message);
        }

        private String _strLast;
        private Boolean _running;
        
        #endregion
    }
}
