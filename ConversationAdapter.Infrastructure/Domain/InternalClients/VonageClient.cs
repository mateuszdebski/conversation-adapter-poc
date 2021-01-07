using Vonage.Applications;
using Vonage.Request;

namespace ConversationAdapter.Infrastructure.Domain.InternalClients
{
    internal interface IVonageClient
    {
        IApplicationClient ApplicationClient { get; }
    }

    internal class VonageClient : IVonageClient
    {
        public IApplicationClient ApplicationClient => Inner.ApplicationClient;

        private Vonage.VonageClient Inner { get; }

        public VonageClient(string username, string secret)
        {
            var credentials = Credentials.FromApiKeyAndSecret(username, secret);
            Inner = new Vonage.VonageClient(credentials);
        }
    }
}