using Microsoft.EntityFrameworkCore;
using WArcherButchers.ServerApp.Infrastructure.Data.DbContexts;

namespace WArcherButchers.Tests.ServerApp.Infrastructure.Entities
{
    public class TestEntityTypeConfigurationFactory : IEntityTypeConfigurationFactory
    {
        public void Initialize(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TestEntityTypeConfiguration());
        }
    }
}