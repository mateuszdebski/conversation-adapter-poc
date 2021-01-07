namespace ConversationAdapter.Domain.Conversation
{
    public class CreatedUser
    {
        public string Id { get; }

        public CreatedUser(string id)
        {
            Id = id;
        }
    }
}