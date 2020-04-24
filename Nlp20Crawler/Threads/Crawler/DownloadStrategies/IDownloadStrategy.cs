using Nlp20Crawler.ORM.Entities;

namespace Nlp20Crawler.Threads.Crawler.DownloadStrategies
{
    // TODO: implement download strategy for javascript websites (e.g. Angular)
    public interface IDownloadStrategy
    {
        public void Download(CrawlerWebsite website);
    }
}