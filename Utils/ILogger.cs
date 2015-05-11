using System;

namespace Utils
{
    public interface ILogger
    {
        void D(String msg, params object[] args);
        void I(String msg, params object[] args);
        void W(String msg, params object[] args);
        void E(String msg, params object[] args);
    }
}
