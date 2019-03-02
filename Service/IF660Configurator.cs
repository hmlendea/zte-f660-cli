using System;

using ZTEF660CLI.Entities;

namespace ZTEF660CLI.Service
{
    public interface IF660Configurator
    {
        bool IsRunning { get; }

        void LogIn(User user);

        Stats GetWanConnectionInfo();
    }
}
