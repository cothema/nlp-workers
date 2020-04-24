using System;
using System.Net;
using Microsoft.Extensions.Logging;
using Nlp20Crawler.ORM.Entities;

namespace Nlp20Crawler.Services.DownloadStrategies
{
    public class SimpleDownloadStrategy : IDownloadStrategy
    {
        private readonly ILogger _logger;

        public SimpleDownloadStrategy(
            ILogger logger
        )
        {
            _logger = logger;
        }

        public void Download(CrawlerWebsite website)
        {
            try
            {
                try
                {
                    using var webClient = new WebClient();
                    website.Html = webClient.DownloadString(website.Url);
                }
                catch (WebException ex)
                {
                    if (((HttpWebResponse) ex.Response).StatusCode == HttpStatusCode.NotFound)
                        website.ResponseCode = 404;

                    website.ResponseCode = 0;
                    website.Html = ((HttpWebResponse) ex.Response).StatusDescription;
                }

                _logger.LogInformation($"Downloaded: {website.Url} with code {website.ResponseCode}");
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                website.Crawled = false;
                website.CrawledTimestamp = null;
                throw;
            }
        }
    }
}