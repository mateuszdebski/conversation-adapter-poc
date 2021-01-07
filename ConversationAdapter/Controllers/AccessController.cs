using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using ConversationAdapter.Application.AccessControl;
using ConversationAdapter.Application.Applications.Delete;
using ConversationAdapter.Results;
using ConversationAdapter.Services.ErrorHandlers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ConversationAdapter.Controllers
{
    [ApiController]
    [Route("api/access")]
    public class AccessController : ControllerBase
    {
        private IMediator Mediator { get; }
        private IErrorFactory ErrorFactory { get; }

        public AccessController(IMediator mediator, IErrorFactory errorFactory)
        {
            Mediator = mediator;
            ErrorFactory = errorFactory;
        }

        [HttpGet]
        [Route("{accountId}/{agentUid}")]
        public async Task<IActionResult> Get([Required] long accountId, [Required] long agentUid)
        {
            var command = new GenerateAgentTokenCommand(agentUid, accountId);
            var result = await Mediator.Send(command);

            if (result.IsSuccess)
            {
                return Ok(result.Result);
            }

            var errorResponse = ErrorFactory.FromCommand(result);
            return new ErrorResult(errorResponse);
        }
    }
}