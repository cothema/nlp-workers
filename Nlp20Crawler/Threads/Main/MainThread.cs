using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Nlp20Crawler.Interfaces;
using Nlp20Crawler.Threads.Crawler;
using Nlp20Crawler.Threads.Proposer;
using Nlp20Crawler.Threads.Scraper;

namespace Nlp20Crawler.Threads.Main
{
    public class MainThread : IThread<IOptions>
    {
        private readonly ILogger _logger;
        private readonly CrawlerThread _crawlerThread;
        private readonly ProposerThread _proposerThread;
        private readonly ScraperThread _scraperThread;

        public MainThread(
            ILogger logger,
            CrawlerThread crawlerThread,
            ProposerThread proposerThread,
            ScraperThread scraperThread
        )
        {
            _logger = logger;
            _crawlerThread = crawlerThread;
            _proposerThread = proposerThread;
            _scraperThread = scraperThread;
        }

        public async Task Run(IOptions? options)
        {
            _logger.LogInformation("■ NLP20Workers started ■");
            
            try
            {
                var workers = new List<Task>
                {
                    // RunThread(_crawlerThread),
                    RunThread(_proposerThread, new ProposerThreadOptions() {}),
                    // RunThread<ScraperThread, IOptions>(_scraperThread, null),
                };

                await Task.WhenAll(workers.ToArray());
            }
            catch (Exception e)
            {
                _logger.LogCritical($"■ Main thread exception: {e.Message}");
            }

            _logger.LogInformation("■ NLP20Workers ended ■");
        }

        private async Task RunThread<TThread, TOptions>(TThread thread, TOptions options)
            where TThread : IThread<TOptions> where TOptions : IOptions?
        {
            try
            {
                await Task.Run(async () => { await thread.Run(options); });
            }
            catch (Exception e)
            {
                _logger.LogCritical($"■ Thread exception ({thread.GetType()}): {e.Message}");
            }
        }
    }
}