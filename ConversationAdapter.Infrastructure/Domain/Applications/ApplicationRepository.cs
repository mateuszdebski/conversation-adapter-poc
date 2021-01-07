using System.Linq;
using System.Threading.Tasks;
using ConversationAdapter.Domain.Applications;
using ConversationAdapter.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace ConversationAdapter.Infrastructure.Domain.Applications
{
    internal class ApplicationRepository : IApplicationRepository
    {
        private ConversationAdapterContext Context { get; }

        public ApplicationRepository(ConversationAdapterContext context)
        {
            Context = context;
        }

        public async Task AddAsync(Application application)
        {
            await Context.Applications.AddAsync(application);
            await Context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Application application)
        {
            Context.Applications.Remove(application);
            await Context.SaveChangesAsync();
        }

        public async Task<Application> GetById(string id)
        {
            return await Context.Applications
                .Where(_ => _.Id == id)
                .SingleOrDefaultAsync();
        }

        public async Task<Application> GetByAccountId(long accountId)
        {
            return await Context.Applications
                .Where(_ => _.AccountId == accountId)
                .SingleOrDefaultAsync();
        }
    }
}