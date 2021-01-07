using ConversationAdapter.Application.Results.Command;
using MediatR;

namespace ConversationAdapter.Application.AccessControl
{
    public class GenerateAgentTokenCommand : IRequest<CreateResult<JwtTokenDto>>
    {
        public long AgentUid { get; }
        public long AccountId { get; }

        public GenerateAgentTokenCommand(long agentUid, long accountId)
        {
            AgentUid = agentUid;
            AccountId = accountId;
        }
    }
}