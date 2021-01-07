using System.Threading;
using System.Threading.Tasks;
using ConversationAdapter.Application.Results.Command;
using ConversationAdapter.Domain.Applications;
using MediatR;

namespace ConversationAdapter.Application.Applications.Delete
{
    public class DeleteApplicationHandler : IRequestHandler<DeleteApplicationCommand, CommandResult>
    {
        private IApplicationClient Client { get; }
        public IApplicationRepository Repository { get; set; }

        public DeleteApplicationHandler(IApplicationClient client, IApplicationRepository repository)
        {
            Client = client; 
            Repository = repository;
        }

        public async Task<CommandResult> Handle(DeleteApplicationCommand command, CancellationToken cancellationToken)
        {
            var application = await Repository.GetById(command.Id);
            if (application == null)
            {
                return CommandResult.FromStatus(CommandResultStatus.NotFound);
            }

            await Client.DeleteAsync(command.Id);
            await Repository.DeleteAsync(application);

            return CommandResult.FromStatus(CommandResultStatus.Success);
        }
    }
}