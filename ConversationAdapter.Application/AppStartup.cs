using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ConversationAdapter.Application
{
    public class AppStartup
    {
        public static void Initialize(IServiceCollection services)
        {
            services.AddMediatR(typeof(AppStartup).Assembly);
        }
    }
}