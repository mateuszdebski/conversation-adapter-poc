using ConversationAdapter.Domain.Applications;
using Microsoft.EntityFrameworkCore;

namespace ConversationAdapter.Infrastructure.Database
{
    public class ConversationAdapterContext : DbContext
    {
        public ConversationAdapterContext()
        {

        }

        public ConversationAdapterContext(DbContextOptions<ConversationAdapterContext> options) : base(options)
        {

        }

        public DbSet<Application> Applications { get; set; }
    }
}