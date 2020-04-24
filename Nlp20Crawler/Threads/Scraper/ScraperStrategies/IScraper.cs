using Nlp20Crawler.ORM.Entities;

namespace Nlp20Crawler.Threads.Scraper.ScraperStrategies
{
    public interface IScraper
    {
        public void Scrape(CrawlerWebsite website);
    }
}