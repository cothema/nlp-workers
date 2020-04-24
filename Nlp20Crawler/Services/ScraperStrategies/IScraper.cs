using Nlp20Crawler.ORM.Entities;

namespace Nlp20Crawler.Services.ScraperStrategies
{
    public interface IScraper
    {
        public void Scrape(CrawlerWebsite website);
    }
}