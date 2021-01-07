using System.Text.Json.Serialization;

namespace ConversationAdapter.Infrastructure.Domain.Conversation.User
{
    public class CreateUserResponse
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
    }
}