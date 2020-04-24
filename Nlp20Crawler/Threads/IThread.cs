using System.Threading.Tasks;
using Nlp20Crawler.Interfaces;

namespace Nlp20Crawler.Threads
{
    public interface IThread<in TOptions> where TOptions : IOptions?
    {
        public Task Run(TOptions options);
    }
}