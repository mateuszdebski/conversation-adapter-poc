using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ConversationAdapter.Infrastructure.Database
{
    public class DatabaseModule
    {
        public static void Init(IServiceCollection services)
        {
            services.AddDbContext<ConversationAdapterContext>(options =>
            {
                options.UseInMemoryDatabase("test");
            });
        }
    }
}