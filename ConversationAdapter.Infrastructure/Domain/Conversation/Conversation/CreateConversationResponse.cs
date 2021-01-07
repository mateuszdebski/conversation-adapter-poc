using System.Text.Json.Serialization;

namespace ConversationAdapter.Infrastructure.Domain.Conversation.Conversation
{
    public class CreateConversationResponse
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
    }
}