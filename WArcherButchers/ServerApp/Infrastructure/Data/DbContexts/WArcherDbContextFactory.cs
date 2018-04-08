using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace WArcherButchers.ServerApp.Infrastructure.Data.DbContexts
{
    public class WArcherDbContextFactory : IWArcherDbContextFactory
    {
        private readonly IDatabaseConnectionStringProvider _databaseConnectionStringProvider;
        private readonly IEntityTypeConfigurationFactory _entityTypeConfigurationFactory;

        public WArcherDbContextFactory(
            IDatabaseConnectionStringProvider databaseConnectionStringProvider,
            IEntityTypeConfigurationFactory entityTypeConfigurationFactory)
        {
            _databaseConnectionStringProvider = databaseConnectionStringProvider ??
                                                throw new ArgumentNullException(
                                                    nameof(databaseConnectionStringProvider));
            _entityTypeConfigurationFactory = entityTypeConfigurationFactory ??
                                              throw new ArgumentNullException(nameof(entityTypeConfigurationFactory));
        }

        public WArcherDbContext CreateDbContext()
        {
            DbContextOptionsBuilder<WArcherDbContext> builder = new DbContextOptionsBuilder<WArcherDbContext>();
#if DEBUG
            builder.EnableSensitiveDataLogging();
#endif
            string connectionString = _databaseConnectionStringProvider.Get();
            builder.UseSqlServer(connectionString,
                optionsBuilder =>
                    optionsBuilder.MigrationsAssembly(typeof(WArcherDbContext).GetTypeInfo().Assembly.GetName()
                        .Name));
            return new WArcherDbContext(builder.Options, _entityTypeConfigurationFactory);
        }
    }
}