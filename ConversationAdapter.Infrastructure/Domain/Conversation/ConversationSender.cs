using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Vonage;

namespace ConversationAdapter.Infrastructure.Domain.Conversation
{
    public interface IConversationSender
    {
        Task<T> SendAsync<T>(HttpRequestMessage request, string applicationId, string key);
        HttpContent CreateContent<T>(T value);
    }

    internal class ConversationSender : IConversationSender
    {
        private IHttpClientFactory Factory { get; }

        public ConversationSender(IHttpClientFactory factory)
        {
            Factory = factory;
        }

        public async Task<T> SendAsync<T>(HttpRequestMessage request, string applicationId, string key)
        {
            var client = Factory.CreateClient(DomainModule.ConversationClientName);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", Jwt.CreateToken(applicationId, key));

            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(content);
        }

        public HttpContent CreateContent<T>(T value) =>
            new StringContent(JsonConvert.SerializeObject(value), Encoding.UTF8, "application/json");
    }
}