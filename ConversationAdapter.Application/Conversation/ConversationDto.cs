namespace ConversationAdapter.Application.Conversation
{
    public class ConversationDto
    {
        public string Id { get; }

        public ConversationDto(string id)
        {
            Id = id;
        }
    }
}