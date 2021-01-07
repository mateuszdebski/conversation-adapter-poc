using System.Threading;
using System.Threading.Tasks;
using ConversationAdapter.Application.Results.Command;
using ConversationAdapter.Domain.AccessControl;
using ConversationAdapter.Domain.Applications;
using MediatR;

namespace ConversationAdapter.Application.AccessControl
{
    public class GenerateAgentTokenHandler : IRequestHandler<GenerateAgentTokenCommand, CreateResult<JwtTokenDto>>
    {
        private IJwtGenerator JwtGenerator { get; }
        private IApplicationRepository ApplicationRepository { get; }

        public GenerateAgentTokenHandler(IJwtGenerator jwtGenerator, IApplicationRepository applicationRepository)
        {
            JwtGenerator = jwtGenerator;
            ApplicationRepository = applicationRepository;
        }

        public async Task<CreateResult<JwtTokenDto>> Handle(GenerateAgentTokenCommand request, CancellationToken cancellationToken)
        {
            var application = await ApplicationRepository.GetByAccountId(request.AccountId);

            var token = JwtGenerator.Generate(application.Id, request.AgentUid.ToString(), AccessControlList.CreateUser(), application.PrivateKey);

            return CreateResult<JwtTokenDto>.FromResult(new JwtTokenDto(token));
        }
    }
}