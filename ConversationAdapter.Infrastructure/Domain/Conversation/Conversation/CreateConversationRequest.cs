using System.Text.Json.Serialization;

namespace ConversationAdapter.Infrastructure.Domain.Conversation.Conversation
{
    internal class CreateConversationRequest
    {
        [JsonPropertyName("name")]
        public string Name { get; }

        [JsonPropertyName("display_name")]
        public string DisplayName { get; }

        private CreateConversationRequest(string name, string displayName)
        {
            Name = name;
            DisplayName = displayName;
        }

        public static CreateConversationRequest Create(string name, string displayName)
        {
            return new CreateConversationRequest(name, displayName);
        }
    }
}