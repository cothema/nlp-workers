using System.Threading.Tasks;
using Nlp20Crawler.Interfaces;
using Nlp20Crawler.ORM.Context;

namespace Nlp20Crawler.Threads.Scraper
{
    // Scrape information from downloaded websites
    public class ScraperThread : IThread<IOptions>
    {
        private PostgreSqlContext _context;
        private EntityManager _entityManager;

        public ScraperThread(
            PostgreSqlContext context,
            EntityManager entityManager
        )
        {
            _context = context;
            _entityManager = entityManager;
        }

        public async Task Run(IOptions? options)
        {
            
        }
    }
}