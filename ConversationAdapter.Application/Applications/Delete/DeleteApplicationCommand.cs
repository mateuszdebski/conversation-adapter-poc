using ConversationAdapter.Application.Results.Command;
using MediatR;

namespace ConversationAdapter.Application.Applications.Delete
{
    public class DeleteApplicationCommand : IRequest<CommandResult>
    {
        public string Id { get; }

        public DeleteApplicationCommand(string id)
        {
            Id = id;
        }
    }
}