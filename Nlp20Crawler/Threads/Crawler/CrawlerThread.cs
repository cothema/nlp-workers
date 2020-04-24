using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Nlp20Crawler.Interfaces;
using Nlp20Crawler.ORM.Context;
using Nlp20Crawler.ORM.Entities;
using Nlp20Crawler.Threads.Crawler.DownloadStrategies;

namespace Nlp20Crawler.Threads.Crawler
{
    public class CrawlerThreadOptions : IOptions
    {
        public int SleepTime = 10000; // in ms
        public int MaxEmptyRuns = 0; // 0 = infinite loop

        public void Validate()
        {
            if (MaxEmptyRuns < 0) throw new ArgumentOutOfRangeException(nameof(MaxEmptyRuns));
            if (SleepTime < 1000) throw new ArgumentOutOfRangeException(nameof(SleepTime));
        }
    }

    public class CrawlerThread : IThread<CrawlerThreadOptions>
    {
        private static readonly SemaphoreSlim SemaphoreDownload = new SemaphoreSlim(2, 2);
        private readonly PostgreSqlContext _context;
        private readonly IDownloadStrategy _downloadStrategy;
        private readonly EntityManager _entityManager;
        private readonly ILogger _logger;

        private readonly IQueryable<CrawlerWebsite> _waitingWebsites;
        private int _emptyRunsCounter;
        private bool _isRunning;

        public CrawlerThread(
            ILogger logger,
            SimpleDownloadStrategy downloadStrategy,
            PostgreSqlContext context,
            EntityManager entityManager
        )
        {
            _logger = logger;
            _downloadStrategy = downloadStrategy;
            _context = context;
            _entityManager = entityManager;
            _waitingWebsites = context.CrawlerWebsites.Where(website => !website.Crawled);
        }

        // Start new crawler thread and process all webpages in queue.
        public async Task Run(
            CrawlerThreadOptions? options
        )
        {
            options ??= new CrawlerThreadOptions();
            options.Validate();

            if (_isRunning)
                return;

            _isRunning = true;

            for (
                _emptyRunsCounter = 0;
                options.MaxEmptyRuns == 0 || _emptyRunsCounter < options.MaxEmptyRuns;
                _emptyRunsCounter++
            )
            {
                await ProcessAllWaitingWebsites();

                _logger.LogInformation($"No more tasks, sleeping for {options.SleepTime} ms.");
                Thread.Sleep(options.SleepTime);
            }

            _logger.LogInformation("Crawler finished its work.");
            _isRunning = false;
        }

        private async Task ProcessAllWaitingWebsites()
        {
            var allTasks = new List<Task>();

            var websites = _waitingWebsites.ToList();

            foreach (var waitingWebsite in websites)
            {
                _emptyRunsCounter = 0;
                await SemaphoreDownload.WaitAsync();
                waitingWebsite.Crawled = true;
                waitingWebsite.CrawledTimestamp = DateTime.Now;
                await _context.SaveChangesAsync();

                allTasks.Add(
                    Task.Run(async () =>
                    {
                        try
                        {
                            _logger.LogInformation($"Processing webpage: {waitingWebsite.Url}");

                            _downloadStrategy.Download(waitingWebsite);

                            await _entityManager.Persist(waitingWebsite);
                            await _entityManager.Flush();
                        }
                        catch (Exception e)
                        {
                            _logger.LogError(e.Message);
                        }
                        finally
                        {
                            SemaphoreDownload.Release();
                        }
                    })
                );
            }

            try
            {
                await Task.WhenAll(allTasks.ToArray());
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
        }
    }
}