using System;
using ConversationAdapter.Domain.AccessControl;
using ConversationAdapter.Domain.Applications;
using ConversationAdapter.Domain.Conversation;
using ConversationAdapter.Infrastructure.Domain.AccessControl;
using ConversationAdapter.Infrastructure.Domain.Applications;
using ConversationAdapter.Infrastructure.Domain.Conversation;
using ConversationAdapter.Infrastructure.Domain.Conversation.Conversation;
using ConversationAdapter.Infrastructure.Domain.InternalClients;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VonageClient = ConversationAdapter.Infrastructure.Domain.InternalClients.VonageClient;

namespace ConversationAdapter.Infrastructure.Domain
{
    public class DomainModule
    {
        public static string ConversationClientName = "Conversation";

        public static void Init(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IApplicationClient, ApplicationClient>();
            services.AddScoped<IApplicationRepository, ApplicationRepository>();
            services.AddScoped<IJwtGenerator, JwtGenerator>();
            services.AddScoped<IConversationClient, ConversationClient>();
            services.AddScoped<IConversationSender, ConversationSender>();

            AddClients(services, configuration);
        }

        private static void AddClients(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IVonageClient>(_ => new VonageClient(configuration["VonageAuth:Username"], configuration["VonageAuth:Secret"]));
            AddConversationClient(services, configuration);
        }

        private static void AddConversationClient(IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient(ConversationClientName, _ =>
            {
                _.BaseAddress = new Uri("https://api.nexmo.com/v0.2/");
            });
        }
    }
}