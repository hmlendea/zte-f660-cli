using System;
using System.Collections.Generic;
using System.Linq;

using NuciCLI;
using NuciCLI.Menus;

using ZTEF660CLI.Entities;

namespace ZTEF660CLI.Menus
{
    /// <summary>
    /// Authentication menu.
    /// </summary>
    public class AuthenticationMenu : Menu
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationMenu"/> class.
        /// </summary>
        public AuthenticationMenu() : base("Authentication")
        {
            AddCommand(
                "login",
                "Logs in a router user",
                delegate { LogIn(); });
        }

        private void LogIn()
        {
            User user = new User();
            user.Username = NuciConsole.ReadLine("Username = ");
            user.Password = NuciConsole.ReadLine("Password = ");

            MainMenu mainMenu = new MainMenu(user);
            mainMenu.Run();
        }
    }
}
