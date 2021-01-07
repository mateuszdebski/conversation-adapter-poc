using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using ConversationAdapter.Application.Applications.Create;
using ConversationAdapter.Application.Applications.Delete;
using ConversationAdapter.Results;
using ConversationAdapter.Services.ErrorHandlers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ConversationAdapter.Controllers.Application
{
    [ApiController]
    [Route("api/application")]
    public class ApplicationController : ControllerBase
    {
        private IMediator Mediator { get; }
        private IErrorFactory ErrorFactory { get; }

        public ApplicationController(IMediator mediator, IErrorFactory errorFactory)
        {
            Mediator = mediator;
            ErrorFactory = errorFactory;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody, Required] CreateApplication request)
        {
            var command = new CreateApplicationCommand(request.Name, request.AccountId.GetValueOrDefault(-1));
            var result = await Mediator.Send(command);

            if (result.IsSuccess)
            {
                return Ok(result.Result);
            }

            var errorResponse = ErrorFactory.FromCommand(result);
            return new ErrorResult(errorResponse);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([Required, MaxLength(50)]string id)
        {
            var command = new DeleteApplicationCommand(id);
            var result = await Mediator.Send(command);

            if (result.IsSuccess)
            {
                return Ok();
            }

            var errorResponse = ErrorFactory.FromCommand(result);
            return new ErrorResult(errorResponse);
        }
    }
}
