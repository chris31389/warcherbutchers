using Microsoft.EntityFrameworkCore;
using WArcherButchers.ServerApp.Infrastructure.Data.DbContexts;

namespace WArcherButchers.Tests.ServerApp.Infrastructure
{
    public class WArcherDbTests : DbTests<WArcherDbContext>
    {
        protected override WArcherDbContext CreateDbContext(DbContextOptions<WArcherDbContext> dbContextOptions)
            => new WArcherDbContext(dbContextOptions, new EntityTypeConfigurationFactory());
    }
}