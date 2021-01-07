using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using ConversationAdapter.Application.Conversation.Create;
using ConversationAdapter.Results;
using ConversationAdapter.Services.ErrorHandlers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ConversationAdapter.Controllers.Conversation
{
    [ApiController]
    [Route("api/conversation")]
    public class ConversationController : ControllerBase
    {
        private IMediator Mediator { get; }
        private IErrorFactory ErrorFactory { get; }

        public ConversationController(IMediator mediator, IErrorFactory errorFactory)
        {
            Mediator = mediator;
            ErrorFactory = errorFactory;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody, Required] CreateConversation request)
        {
            var command = new CreateConversationCommand(request.AccountId.GetValueOrDefault(-1), request.Name);
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