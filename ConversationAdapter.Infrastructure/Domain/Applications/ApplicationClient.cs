using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ConversationAdapter.Domain.Applications;
using ConversationAdapter.Infrastructure.Domain.InternalClients;
using Vonage.Applications;
using Vonage.Applications.Capabilities;
using Vonage.Common;
using IApplicationClient = ConversationAdapter.Domain.Applications.IApplicationClient;

namespace ConversationAdapter.Infrastructure.Domain.Applications
{
    internal class ApplicationClient : IApplicationClient
    {
        private IVonageClient Client { get; }

        public ApplicationClient(IVonageClient vonageClient)
        {
            Client = vonageClient;
        }

        public async Task<CreatedApplication> CreateAsync(string name, Uri webhookUri)
        {
            var webHooks = new Dictionary<Webhook.Type, Webhook>
            {
                {Webhook.Type.event_url, new Webhook {Address = webhookUri.AbsoluteUri, Method = HttpMethod.Post.ToString().ToUpper()}}
            };

            var request = new CreateApplicationRequest { Name = name, Capabilities = new ApplicationCapabilities { Rtc = new Rtc(webHooks) } };

            var result = await Client.ApplicationClient.CreateApplicaitonAsync(request);
            
            return new CreatedApplication(result.Id, result.Name, result.Keys.PrivateKey, result.Keys.PublicKey);
        }

        public async Task<bool> DeleteAsync(string id)
        {
            return await Client.ApplicationClient.DeleteApplicationAsync(id);
        }
    }
}