using System.Net;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Nlp20Crawler.ORM.Context;
using Nlp20Crawler.Services;
using Nlp20Crawler.Threads;
using Nlp20Crawler.Threads.Crawler;
using Nlp20Crawler.Threads.Crawler.DownloadStrategies;
using Nlp20Crawler.Threads.Main;
using Nlp20Crawler.Threads.Proposer;
using Nlp20Crawler.Threads.Proposer.ProposerStrategies;
using Nlp20Crawler.Threads.Scraper;
using Nlp20Crawler.Threads.Scraper.ScraperStrategies;

namespace Nlp20Crawler
{
    internal class Program
    {
        internal static void Main(string[] args)
        {
            var serviceProvider = SetupDi();
            serviceProvider.GetService<MainThread>()
                .Run(null)
                .Wait();
        }

        private static ServiceProvider SetupDi()
        {
            return new ServiceCollection()
                // System
                .AddLogging(
                    builder => builder.AddConsole().SetMinimumLevel(LogLevel.Debug)
                )
                .AddSingleton<ILogger>(
                    serviceProvider
                        => serviceProvider
                            .GetService<ILoggerFactory>()
                            .CreateLogger<Program>()
                )
                // Threads
                .AddSingleton<CrawlerThread>()
                .AddSingleton<MainThread>()
                .AddSingleton<ProposerThread>()
                .AddSingleton<WikipediaCsNounProposeStrategy>()
                .AddSingleton<ScraperThread>()
                // Database
                .AddSingleton<EntityManager>()
                .AddDbContext<PostgreSqlContext>(ServiceLifetime.Scoped)
                // External services
                .AddTransient<WebClient>()
                // Services
                .AddSingleton<NodeApi>()
                .AddSingleton<SimpleScraper>()
                .AddSingleton<SimpleDownloadStrategy>()
                .BuildServiceProvider();
        }
    }
}