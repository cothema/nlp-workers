using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Nlp20Crawler.ORM.Context
{
    // Thread safe entity manager
    public class EntityManager
    {
        // Writer can handle max. 1 request in same time
        private static readonly SemaphoreSlim SemaphoreWriter = new SemaphoreSlim(1, 1);
        private readonly DbContext _writeContext;

        public EntityManager(
            IServiceScopeFactory serviceScopeFactory,
            PostgreSqlContext readContext
        )
        {
            var scope = serviceScopeFactory.CreateScope();
            _writeContext = scope.ServiceProvider.GetService<PostgreSqlContext>();
        }

        // Persist concrete entity to writer context
        public async Task<T> Persist<T>([NotNull] T entity)
        {
            await SemaphoreWriter.WaitAsync();

            _writeContext.Update(entity);

            SemaphoreWriter.Release();
            return entity;
        }

        // Save all persisted changes to database
        public async Task<int> Flush()
        {
            var writtenCount = -1;
            try
            {
                await SemaphoreWriter.WaitAsync();

                writtenCount = await _writeContext.SaveChangesAsync();
            }
            finally
            {
                SemaphoreWriter.Release();
            }

            return writtenCount;
        }
    }
}