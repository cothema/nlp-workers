using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Nlp20Crawler.Config
{
    // See: https://www.frakkingsweet.com/add-usersecrets-to-net-core-console-application/
    public class ConfigServiceProviderBuilder
    {
        public static IServiceProvider GetServiceProvider(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile(@"appsettings.json", true, true)
                .AddEnvironmentVariables()
                .AddUserSecrets(typeof(Program).Assembly)
                .AddCommandLine(args)
                .Build();
            var services = new ServiceCollection();

            services.Configure<AppSecrets>(configuration.GetSection(typeof(AppSecrets).FullName));

            var provider = services.BuildServiceProvider();
            return provider;
        }
    }
}