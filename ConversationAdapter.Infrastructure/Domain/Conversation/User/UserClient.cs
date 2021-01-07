using System.Net.Http;
using System.Threading.Tasks;
using ConversationAdapter.Domain.Conversation;

namespace ConversationAdapter.Infrastructure.Domain.Conversation.User
{
    public class UserClient : IUserClient
    {
        private IConversationSender Sender { get; }

        public UserClient(IConversationSender sender)
        {
            Sender = sender;
        }

        public async Task<CreatedUser> CreateAsync(string name, string displayName, string applicationId, string key)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "users")
            {
                Content = Sender.CreateContent(new CreateUserRequest(name, displayName))
            };

            var response = await Sender.SendAsync<CreateUserResponse>(request, applicationId, key);

            return new CreatedUser(response.Id);
        }
    }
}