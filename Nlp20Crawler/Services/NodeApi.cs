using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using Nlp20Crawler.ORM.Entities;

namespace Nlp20Crawler.Services
{
    // https://nlp20.herokuapp.com/
    public class NodeApi
    {
        private static readonly SemaphoreSlim Semaphore = new SemaphoreSlim(5);

        private static Task Post(
            [NotNull] CrawlerWebsite webpage
        )
        {
            throw new NotImplementedException();
        }
    }
}