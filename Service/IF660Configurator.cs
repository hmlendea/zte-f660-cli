using System;

namespace ZTEF660CLI.Service
{
    public interface IF660Configurator
    {
        bool IsRunning { get; }

        void LogIn();
    }
}
