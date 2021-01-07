using System;
using System.Net;
using ConversationAdapter.Application.Results.Command;
using ConversationAdapter.Application.Results.Query;

namespace ConversationAdapter.Services.ErrorHandlers
{
    public interface IErrorFactory
    {
        ErrorResponse FromCommand(CommandResult result);
    }

    public class ErrorFactory : IErrorFactory
    {
        public ErrorResponse FromCommand(CommandResult result)
        {
            var statusCode = ToHttpStatus(result.Status);
            return new ErrorResponse(statusCode, result.Messages);
        }

        private static HttpStatusCode ToHttpStatus(CommandResultStatus value)
        {
            return value switch
            {
                CommandResultStatus.Success => HttpStatusCode.OK,
                CommandResultStatus.NotFound => HttpStatusCode.NotFound,
                CommandResultStatus.Error => HttpStatusCode.InternalServerError,
                _ => throw new ArgumentOutOfRangeException(nameof(CommandResultStatus), value, null)
            };
        }

        private static HttpStatusCode ToHttpStatus(QueryResultStatus value)
        {
            return value switch
            {
                QueryResultStatus.Success => HttpStatusCode.OK,
                QueryResultStatus.Error => HttpStatusCode.InternalServerError,
                _ => throw new ArgumentOutOfRangeException(nameof(QueryResultStatus), value, null)
            };
        }
    }
}