using ConversationAdapter.Application.Results.Command;
using MediatR;

namespace ConversationAdapter.Application.Applications.Create
{
    public class CreateApplicationCommand : IRequest<CreateResult<ApplicationDto>>
    {
        public string Name { get; }
        public long AccountId { get; }

        public CreateApplicationCommand(string name, long accountId)
        {
            Name = name;
            AccountId = accountId;
        }
    }
}