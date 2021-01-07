using System.Threading.Tasks;

namespace ConversationAdapter.Domain.Conversation
{
    public interface IUserClient
    {
        Task<CreatedUser> CreateAsync(string name, string displayName, string applicationId, string key);
    }
}