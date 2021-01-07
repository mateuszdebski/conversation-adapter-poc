using System;
using System.Threading.Tasks;

namespace ConversationAdapter.Domain.Applications
{
    public interface IApplicationClient
    {
        Task<CreatedApplication> CreateAsync(string name, Uri webhookUri);
        Task<bool> DeleteAsync(string id);
    }
}