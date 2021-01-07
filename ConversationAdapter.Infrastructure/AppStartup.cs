using ConversationAdapter.Infrastructure.Database;
using ConversationAdapter.Infrastructure.Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ConversationAdapter.Infrastructure
{
    public class AppStartup
    {
        public static void Initialize(IServiceCollection services, IConfiguration configuration)
        {
            DatabaseModule.Init(services);
            DomainModule.Init(services, configuration);
        }
    }
}
