using System.Net.Http;
using System.Threading.Tasks;
using ConversationAdapter.Domain.Conversation;

namespace ConversationAdapter.Infrastructure.Domain.Conversation.Conversation
{
    internal class ConversationClient : IConversationClient
    {
        private IConversationSender Sender { get; }

        public ConversationClient(IConversationSender sender)
        {
            Sender = sender;
        }

        public async Task<CreatedConversation> CreateAsync(string name, string displayName, string applicationId, string key)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "conversations")
            {
                Content = Sender.CreateContent(CreateConversationRequest.Create(name, displayName))
            };

            var response = await Sender.SendAsync<CreateConversationResponse>(request, applicationId, key);

            return new CreatedConversation(response.Id);
        }
    }
}