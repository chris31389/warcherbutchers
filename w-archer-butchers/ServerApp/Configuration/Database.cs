using Microsoft.Extensions.Configuration;
using WArcherButchers.ServerApp.Infrastructure.Data.DbContexts;

namespace WArcherButchers.ServerApp.Configuration
{
    public class Database : IDatabase
    {
        public string ConnectionString { get; }

        public Database() : this(new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", true, true)
            .Build())
        {
        }

        public Database(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("Database");
        }
    }
}