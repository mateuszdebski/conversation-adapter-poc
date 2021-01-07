using System.Collections.Generic;
using System.Net;
using System.Text.Json.Serialization;

namespace ConversationAdapter.Services.ErrorHandlers
{
    public class ErrorResponse
    {
        [JsonPropertyName("statusCode")]
        public HttpStatusCode Code { get; set; }

        [JsonPropertyName("errors")]
        public IEnumerable<string> Errors { get; }

        public ErrorResponse(HttpStatusCode code, IEnumerable<string> errors)
        {
            Code = code;
            Errors = errors;
        }
    }
}