using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

using ZTEF660CLI.Configuration;
using ZTEF660CLI.Logging;
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
            IConfiguration config = LoadConfiguration();

            DebugSettings debugSettings = new DebugSettings();
            config.Bind(nameof(DebugSettings), debugSettings);
            
            IServiceProvider serviceProvider = new ServiceCollection()
                .AddSingleton(debugSettings)
                .AddSingleton<ILogger, Logger>()
                .AddSingleton<IF660Configurator, F660Configurator>()
                .BuildServiceProvider();

            logger = serviceProvider.GetService<ILogger>();

            logger.Info($"Application started");

            IF660Configurator f660 = serviceProvider.GetService<IF660Configurator>();
            f660.LogIn();

            logger.Info($"Application stopped");
        }
        
        static IConfiguration LoadConfiguration()
        {
            return new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .Build();
        }
    }
}
