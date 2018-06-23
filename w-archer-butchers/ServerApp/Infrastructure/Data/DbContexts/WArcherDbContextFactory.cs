using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using WArcherButchers.ServerApp.Configuration;

namespace WArcherButchers.ServerApp.Infrastructure.Data.DbContexts
{
    public class WArcherDbContextFactory : IWArcherDbContextFactory, IDesignTimeDbContextFactory<WArcherDbContext>
    {
        private readonly IDatabase _database;
        private readonly IEntityTypeConfigurationFactory _entityTypeConfigurationFactory;

        public WArcherDbContextFactory(
            IDatabase database,
            IEntityTypeConfigurationFactory entityTypeConfigurationFactory)
        {
            _database = database ??
                        throw new ArgumentNullException(
                            nameof(database));
            _entityTypeConfigurationFactory = entityTypeConfigurationFactory ??
                                              throw new ArgumentNullException(nameof(entityTypeConfigurationFactory));
        }

        public WArcherDbContextFactory()
        {
            _database = new Database();
            _entityTypeConfigurationFactory = new EntityTypeConfigurationFactory();
        }

        public WArcherDbContext CreateDbContext()
        {
            DbContextOptionsBuilder<WArcherDbContext> builder = new DbContextOptionsBuilder<WArcherDbContext>();
#if DEBUG
            builder.EnableSensitiveDataLogging();
#endif
            builder.UseSqlServer(_database.ConnectionString);
            return new WArcherDbContext(builder.Options, _entityTypeConfigurationFactory);
        }

        public WArcherDbContext CreateDbContext(string[] args) => CreateDbContext();
    }
}