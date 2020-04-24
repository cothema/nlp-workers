using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nlp20Crawler.Extensions;
using Nlp20Crawler.Interfaces;
using Nlp20Crawler.ORM.Context;
using Nlp20Crawler.ORM.Entities;

namespace Nlp20Crawler.Threads
{
    public class ProposerThreadOptions : IOptions
    {
        public int StepCount = 50; // in ms
        public int FlushAfterCount = 50; // 0 = infinite loop

        public void Validate()
        {
            if (StepCount < 1) throw new ArgumentOutOfRangeException(nameof(StepCount));
            if (FlushAfterCount < 1) throw new ArgumentOutOfRangeException(nameof(FlushAfterCount));
        }
    }

    public class ProposerThread : IThread<ProposerThreadOptions>
    {
        private readonly PostgreSqlContext _context;
        private readonly EntityManager _entityManager;

        public ProposerThread(
            PostgreSqlContext context,
            EntityManager entityManager
        )
        {
            _context = context;
            _entityManager = entityManager;
        }

        public async Task Run(
            ProposerThreadOptions? options
        )
        {
            options ??= new ProposerThreadOptions();
            options.Validate();

            List<Word> words;

            do
            {
                words = _context.Words.Where(
                        word => word.Lang == "cs"
                                && word.CrawlerMeaningCheckProposed != true
                                && word.Probability > -100
                    )
                    // .OrderBy(r => Guid.NewGuid()) // Random order
                    .Take(options.StepCount)
                    .ToList();

                int counter = 0;
                foreach (var word in words)
                {
                    counter++;
                    word.CrawlerMeaningCheckProposed = true;
                    word.CrawlerMeaningCheckProposedTime = DateTime.Now;

                    var crawlerWebsite = new CrawlerWebsite
                    {
                        Url = "https://cs.wikipedia.org/wiki/" + word.Text.FirstCharToUpper()
                    };

                    await _entityManager.Persist(word);
                    await _entityManager.Persist(crawlerWebsite);

                    if (counter % options.FlushAfterCount == 0)
                    {
                        await _entityManager.Flush();
                    }
                }

                await _entityManager.Flush();
            } while (words.Count > 0);
        }
    }
}