using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using NuciCLI.Menus;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

using ZTEF660CLI.Configuration;
using ZTEF660CLI.Entities;
using ZTEF660CLI.Logging;
using ZTEF660CLI.Menus;
using ZTEF660CLI.Service;

namespace ZTEF660CLI
{
    public sealed class Program
    {
        static TimeSpan RetryDelay => TimeSpan.FromSeconds(10);
        
        static TimeSpan ConnectionWaitTime => TimeSpan.FromMinutes(15);

        static ILogger logger;

        static void Main(string[] args)
        {
            IOC.SetUp();

            logger = IOC.GetService<ILogger>();

            logger.Info($"Application started");
            
            MenuManager.Instance.OpenMenu(typeof(AuthenticationMenu));

            logger.Info($"Application stopped");
        }

        static void PrintStats(Stats stats)
        {
            Console.WriteLine("IP Address".PadRight(21) + stats.IpAddress);
        }
    }
}
