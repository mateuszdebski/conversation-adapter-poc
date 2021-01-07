namespace ConversationAdapter.Infrastructure.Domain.Conversation.User
{
    public class CreateUserRequest
    {
        public string Name { get; }
        public string DisplayName { get; }

        public CreateUserRequest(string name, string displayName)
        {
            Name = name;
            DisplayName = displayName;
        }
    }
}