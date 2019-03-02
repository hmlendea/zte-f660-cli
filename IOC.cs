using System;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using ZTEF660CLI.Configuration;
using ZTEF660CLI.Logging;
using ZTEF660CLI.Service;

namespace ZTEF660CLI
{
    public static class IOC
    {
        static IServiceProvider serviceProvider;

        public static void SetUp()
        {
            IConfiguration config = LoadConfiguration();

            DebugSettings debugSettings = new DebugSettings();
            config.Bind(nameof(DebugSettings), debugSettings);

            serviceProvider = new ServiceCollection()
                .AddSingleton(debugSettings)
                .AddSingleton<ILogger, Logger>()
                .AddSingleton<IF660Configurator, F660Configurator>()
                .BuildServiceProvider();
        }

        public static T GetService<T>()
            => serviceProvider.GetService<T>();
        
        static IConfiguration LoadConfiguration()
        {
            IConfigurationBuilder configurationBuilder =
                new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json", true, true);
            
            IConfiguration configuration = configurationBuilder.Build();

            return configuration;
        }
    }
}
