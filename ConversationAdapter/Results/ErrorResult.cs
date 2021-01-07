using ConversationAdapter.Services.ErrorHandlers;
using Microsoft.AspNetCore.Mvc;

namespace ConversationAdapter.Results
{
    public class ErrorResult : ObjectResult
    {
        public ErrorResult(ErrorResponse response) : base(response)
        {
            StatusCode = (int) response.Code;
        }
    }
}