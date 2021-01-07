using System;
using System.Threading;
using System.Threading.Tasks;
using ConversationAdapter.Application.Results.Command;
using ConversationAdapter.Domain.Applications;
using MediatR;

namespace ConversationAdapter.Application.Applications.Create
{
    public class CreateApplicationHandler : IRequestHandler<CreateApplicationCommand, CreateResult<ApplicationDto>>
    {
        private static readonly Uri WebhookUri = new Uri("https://webhook.site/c7a35fe0-877b-4c10-b578-5669dce4566a");
        private IApplicationClient Client { get; }
        private IApplicationRepository Repository { get; set; }

        public CreateApplicationHandler(IApplicationClient client, IApplicationRepository repository)
        {
            Client = client; 
            Repository = repository;
        }

        public async Task<CreateResult<ApplicationDto>> Handle(CreateApplicationCommand command, CancellationToken cancellationToken)
        {
            var result = await Client.CreateAsync(command.Name, WebhookUri);

            await Save(result, command.AccountId);

            return CreateResult<ApplicationDto>.FromResult(new ApplicationDto(result.Id));
        }

        private async Task Save(CreatedApplication createdApplication, long accountId)
        {
            var entity = new Domain.Applications.Application(createdApplication.Id, accountId, createdApplication.Name, createdApplication.PrivateKey, createdApplication.PublicKey);
            await Repository.AddAsync(entity);
        }
    }
}