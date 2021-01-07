using ConversationAdapter.Application.Results.Command;
using MediatR;

namespace ConversationAdapter.Application.Conversation.Create
{
    public class CreateConversationCommand : IRequest<CreateResult<ConversationDto>>
    {
        public long AccountId { get; }
        public string Name { get; }

        public CreateConversationCommand(long accountId, string name)
        {
            AccountId = accountId;
            Name = name;
        }
    }
}