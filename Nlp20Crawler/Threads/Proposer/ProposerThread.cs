using System;
using System.Threading.Tasks;
using Nlp20Crawler.Interfaces;
using Nlp20Crawler.Threads.Proposer.ProposerStrategies;

namespace Nlp20Crawler.Threads.Proposer
{
    public class ProposerThreadOptions : IOptions
    {
        public int StepCount = 5;
        public int FlushAfterCount = 10;
        public int SleepTime = 1000; // in ms

        public void Validate()
        {
            if (StepCount < 1) throw new ArgumentOutOfRangeException(nameof(StepCount));
            if (FlushAfterCount < 1) throw new ArgumentOutOfRangeException(nameof(FlushAfterCount));
            if (SleepTime < 0) throw new ArgumentOutOfRangeException(nameof(SleepTime));
        }
    }

    // Propose new websites to be crawled
    public class ProposerThread : IThread<ProposerThreadOptions>
    {
        private readonly WikipediaCsNounProposeStrategy _wikipediaCsNounProposeStrategy;

        public ProposerThread(
            WikipediaCsNounProposeStrategy wikipediaCsNounProposeStrategy
        )
        {
            _wikipediaCsNounProposeStrategy = wikipediaCsNounProposeStrategy;
        }

        public async Task Run(
            ProposerThreadOptions? options
        )
        {
            options ??= new ProposerThreadOptions();
            options.Validate();

            await _wikipediaCsNounProposeStrategy.Propose(options);
        }
    }
}