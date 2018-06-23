using Microsoft.EntityFrameworkCore;

namespace WArcherButchers.ServerApp.Infrastructure.Data.DbContexts
{
    public interface IEntityTypeConfigurationFactory
    {
        void Initialize(ModelBuilder modelBuilder);
    }
}