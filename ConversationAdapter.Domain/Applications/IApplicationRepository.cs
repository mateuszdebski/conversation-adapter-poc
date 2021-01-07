using System.Threading.Tasks;

namespace ConversationAdapter.Domain.Applications
{
    public interface IApplicationRepository
    {
        Task AddAsync(Application application);
        Task DeleteAsync(Application application);
        Task<Application> GetById(string id);
        Task<Application> GetByAccountId(long accountId);
    }
}