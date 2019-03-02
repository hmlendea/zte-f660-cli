using System;
using System.Collections.Generic;
using System.Linq;

using NuciCLI;
using NuciCLI.Menus;

using ZTEF660CLI;
using ZTEF660CLI.Entities;
using ZTEF660CLI.Service;

namespace ZTEF660CLI.Menus
{
    /// <summary>
    /// Main menu.
    /// </summary>
    public class MainMenu : Menu
    {
        readonly IF660Configurator f660;
        readonly User user;

        public MainMenu(User user) : base("Main Menu")
        {
            this.user = user;

            f660 = IOC.GetService<IF660Configurator>();
            f660.LogIn(user);

            AreStatisticsEnabled = true;

            AddCommand(
                "get-wan-connection-info",
                "Logs in a router user",
                delegate { GetWanConnectionInfo(); });
        }

        private void GetWanConnectionInfo()
        {
            Stats wanInfo = f660.GetWanConnectionInfo();

            NuciConsole.WriteLine($"{"IP Address".PadRight(20)} {wanInfo.IpAddress}");
        }
    }
}
