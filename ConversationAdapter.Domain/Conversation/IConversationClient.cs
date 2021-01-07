using System.Threading.Tasks;

namespace ConversationAdapter.Domain.Conversation
{
    public interface IConversationClient
    {
        Task<CreatedConversation> CreateAsync(string name, string displayName, string applicationId, string key);
    }
}