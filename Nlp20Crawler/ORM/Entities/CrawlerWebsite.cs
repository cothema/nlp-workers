using System;

namespace Nlp20Crawler.ORM.Entities
{
    public class CrawlerWebsite
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public bool Crawled { get; set; }
        public DateTime? CrawledTimestamp { get; set; }
        public int? ResponseCode { get; set; }
        public string? Html { get; set; }
    }
}