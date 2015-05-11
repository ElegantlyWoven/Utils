using System;

namespace Utils
{
    public interface ISuspendable
    {
        void Suspend();
        void Resume();
    }
}
