using System;

using NuciWeb;
using OpenQA.Selenium;

using ZTEF660CLI.Configuration;
using ZTEF660CLI.Entities;

namespace ZTEF660CLI.Service
{
    public sealed class F660Processor : WebProcessor
    {
        public static string BaseUrl => "http://192.168.1.1";

        public static string LoginUrl => BaseUrl;

        public static string HomePageUrl => $"{BaseUrl}/start.ghtml";

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

        public Stats GetWanConnectionInfo()
        {
            GoToUrl(HomePageUrl);
            
            By wanConnectionInfoButtonSelector = By.Id("ssmDSLWANv46Conn");
            Click(wanConnectionInfoButtonSelector);

            By typeSelector = By.Id("TextWANCName0");
            By connectionNameSelector = By.Id("TextWANCName0");
            By ipVersionSelector = By.Id("TextPPPIpMode0");
            By natSelector = By.Id("TextPPPIsNAT0");
            By ipSelector = By.Id("TextPPPIPAddress0");
            By dnsSelector = By.Id("TextPPPDNS0");
            By ipv4StatusSelector = By.Id("TextPPPConStatus0");
            By ipv6StatusSelector = By.Id("TextPPPConnStatusV60");
            By ipv4DurationSelector = By.Id("TextPPPUpTime0");
            By ipv6DurationSelector = By.Id("TextPPPUpTimeV60");
            By llaSelector = By.Id("TextPPPLLA0");
            By guaSelector = By.Id("TextPPPGua10");
            By dns2Selector = By.Id("TextPPPDNSv60");
            By prefixDelegationSelector = By.Id("TextPPPIsPD0");
            By delegatingPrefixAddressSelector = By.Id("TextPPPGuaPD0");
            By wanMacSelector = By.Id("TextPPPWorkIFMac0");

            Stats stats = new Stats();
            stats.Type = GetValue(typeSelector);
            stats.ConnectionName = GetValue(connectionNameSelector);
            stats.InternetProtocolVersion = GetValue(ipVersionSelector);
            stats.HasNetworkAddressTranslation = GetValue(natSelector) == "Enabled";
            stats.IpAddress = GetValue(ipSelector);
            stats.DomainNameSystems = GetValue(dnsSelector).Split('/');
            stats.IsIpV4Connected = GetValue(ipv4StatusSelector) == "Connected";
            stats.IsIpV6Connected = GetValue(ipv6StatusSelector) == "Connected";
            stats.IpV4OnlineDuration = TimeSpan.FromSeconds(int.Parse(GetValue(ipv4DurationSelector)));
            stats.IpV6OnlineDuration = TimeSpan.FromSeconds(int.Parse(GetValue(ipv6DurationSelector)));
            stats.LLA = GetValue(llaSelector);
            stats.GUA = GetValue(guaSelector);
            stats.DNS = GetValue(dns2Selector);
            stats.HasPrefixDelegation = GetValue(prefixDelegationSelector) == "Yes";
            stats.DelegatingPrefixAddress = GetValue(delegatingPrefixAddressSelector);
            stats.WanMacAddress = GetValue(wanMacSelector);

            return stats;
        }
    }
}
