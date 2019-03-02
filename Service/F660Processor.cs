using NuciWeb.Processors;
using OpenQA.Selenium;

using ZTEF660CLI.Configuration;
using ZTEF660CLI.Entities;

namespace ZTEF660CLI.Service
{
    public sealed class F660Processor : WebProcessor
    {
        public static string BaseUrl => "http://192.168.1.1";

        public static string LoginUrl => BaseUrl;

        // TODO: Temporary - remove this after
        readonly IWebDriver driver;

        // TODO: Temporary - remove this after
        readonly DebugSettings debugSettings;

        readonly User user;

        public F660Processor(IWebDriver driver, DebugSettings debugSettings, User user)
            : base(driver)
        {
            this.driver = driver;
            this.debugSettings = debugSettings;
            this.user = user;
        }

        public void LogIn()
        {
            GoToUrl(LoginUrl);

            By usernameSelector = By.Id("Frm_Username");
            By passwordSelector = By.Id("Frm_Password");
            By loginButtonSelector = By.Id("LoginId");

            SetText(usernameSelector, user.Username);
            SetText(passwordSelector, user.Password);

            Click(loginButtonSelector);
        }
    }
}
