using Microsoft.EntityFrameworkCore;
using WArcherButchers.ServerApp.Infrastructure.Data.DbContexts;

namespace WArcherButchers.Tests.ServerApp.Infrastructure.Entities
{
    public class TestDbContext : WArcherDbContext
    {
        public TestDbContext(DbContextOptions options, IEntityTypeConfigurationFactory entityTypeConfigurationFactory) :
            base(options, entityTypeConfigurationFactory)
        {
        }
    }
}