using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nlp20Crawler.Extensions;
using Nlp20Crawler.ORM.Context;
using Nlp20Crawler.ORM.Entities;

namespace Nlp20Crawler.Threads.Proposer.ProposerStrategies
{
    public class WikipediaCsNounProposeStrategy
    {
        private readonly PostgreSqlContext _context;
        private readonly EntityManager _entityManager;

        public WikipediaCsNounProposeStrategy(
            PostgreSqlContext context,
            EntityManager entityManager
        )
        {
            _context = context;
            _entityManager = entityManager;
        }

        public async Task Propose(
            ProposerThreadOptions? options
        )
        {
            options ??= new ProposerThreadOptions();
            options.Validate();

            List<CsWordNounSpecification> wordsNounSpec;

            do
            {
                wordsNounSpec = _context.CsWordNounSpecifications
                    .Include(e => e.Word)
                    .Where(
                        specification => specification.CrawlerProposedWiki != true
                                         && specification.DeclensionSg1 == true
                                         && specification.Word.CrawlerMeaningCheckProposed != true
                    )
                    .OrderBy(r => Guid.NewGuid()) // Random order (warning: it is very slow operation!)
                    .Take(options.StepCount)
                    .ToList();

                int counter = 0;
                foreach (var wordNounSpec in wordsNounSpec)
                {
                    counter++;
                    wordNounSpec.CrawlerProposedWiki = true;
                    wordNounSpec.Word.CrawlerMeaningCheckProposed = true;
                    wordNounSpec.Word.CrawlerMeaningCheckProposedTime = DateTime.Now;

                    var crawlerWebsite = new CrawlerWebsite
                    {
                        Url = $"https://cs.wikipedia.org/wiki/{wordNounSpec.Word.Text.FirstCharToUpper()}",
                        WordId = wordNounSpec.WordId
                    };

                    await _entityManager.Persist(wordNounSpec);
                    await _entityManager.Persist(crawlerWebsite);

                    if (counter % options.FlushAfterCount == 0)
                    {
                        await _entityManager.Flush();
                    }
                }

                await _entityManager.Flush();
                Thread.Sleep(options.SleepTime);
            } while (wordsNounSpec.Count > 0);
        }
    }
}