namespace ConversationAdapter.Domain.Conversation
{
    public class CreatedConversation
    {
        public string Id { get; }

        public CreatedConversation(string id)
        {
            Id = id;
        }
    }
}