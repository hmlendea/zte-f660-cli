using System;
using System.Net;
using System.Threading;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

using ZTEF660CLI.Configuration;
using ZTEF660CLI.Entities;
using ZTEF660CLI.Logging;

namespace ZTEF660CLI.Service
{
    public class F660Configurator : IF660Configurator
    {
        public bool IsRunning { get; private set; }

        readonly DebugSettings debugSettings;

        readonly ILogger logger;

        readonly IWebDriver driver;

        F660Processor processor;
        
        public F660Configurator(
            DebugSettings debugSettings,
            ILogger logger)
        {
            this.debugSettings = debugSettings;
            this.logger = logger;

            driver = SetupDriver();
        }

        public void LogIn()
        {
            User user = new User
            {
                Username = PromptForValue(nameof(user.Username)),
                Password = PromptForValue(nameof(user.Password))
            };

            if (!(processor is null))
            {
                processor.Dispose();
            }
            
            processor = new F660Processor(driver, debugSettings, user);
            processor.LogIn();
        }

        IWebDriver SetupDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.PageLoadStrategy = PageLoadStrategy.None;
            options.AddArgument("--silent");
			options.AddArgument("--disable-translate");
			options.AddArgument("--disable-infobars");
            options.AddArgument("--disable-extensions");
            options.AddArgument("--headless");
            options.AddArgument("--disable-gpu");
            options.AddArgument("--window-size=1920,1080");
            options.AddArgument("--start-maximized");
            options.AddArgument("--blink-settings=imagesEnabled=false");

            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
            service.SuppressInitialDiagnosticInformation = true;
            service.HideCommandPromptWindow = true;

            IWebDriver driver = new ChromeDriver(service, options);
            driver.Manage().Window.Maximize();

            return driver;
        }

        string PromptForValue(string prompt)
        {
            Console.Write($"Enter the '{prompt}': ");
            string value = Console.ReadLine();

            return value;
        }
    }
}
