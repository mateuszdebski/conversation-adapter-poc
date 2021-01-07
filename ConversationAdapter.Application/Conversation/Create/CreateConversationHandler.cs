using System.Threading;
using System.Threading.Tasks;
using ConversationAdapter.Application.Results.Command;
using ConversationAdapter.Domain.Applications;
using ConversationAdapter.Domain.Conversation;
using MediatR;

namespace ConversationAdapter.Application.Conversation.Create
{
    public class CreateConversationHandler : IRequestHandler<CreateConversationCommand, CreateResult<ConversationDto>>
    {
        private IConversationClient Client { get; }
        private IApplicationRepository Repository { get; }

        public CreateConversationHandler(IConversationClient client, IApplicationRepository repository)
        {
            Client = client; 
            Repository = repository;
        }

        public async Task<CreateResult<ConversationDto>> Handle(CreateConversationCommand request, CancellationToken cancellationToken)
        {
            var application = await Repository.GetByAccountId(request.AccountId);

            var conversation = await Client.CreateAsync(request.Name, request.Name, application.Id, application.PrivateKey);

            return CreateResult<ConversationDto>.FromResult(new ConversationDto(conversation.Id));
        }
    }
}