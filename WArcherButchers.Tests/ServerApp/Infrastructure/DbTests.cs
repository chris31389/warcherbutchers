using System.Data.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using WArcherButchers.ServerApp.Infrastructure.Data.DbContexts;

namespace WArcherButchers.Tests.ServerApp.Infrastructure
{
    public abstract class DbTests<T>
        where T : WArcherDbContext
    {
        private DbConnection DbConnection { get; set; }

        protected DbContext GetDbContext()
        {
            DbContextOptions<T> options = new DbContextOptionsBuilder<T>()
                .UseSqlServer(DbConnection)
                .EnableSensitiveDataLogging()
                .Options;

            T dbContext = CreateDbContext(options);
            return dbContext;
        }

        protected abstract T CreateDbContext(DbContextOptions<T> dbContextOptions);

        [SetUp]
        public async Task DbSetup()
        {
            DbConnection = new SqlConnection(MySetupClass.TestDatabaseConnectionString);

            using (DbContext dbContext = GetDbContext())
            {
                await dbContext.Database.EnsureCreatedAsync();
            }
        }

        [TearDown]
        public async Task DbTearDown()
        {
            using (DbContext dbContext = GetDbContext())
            {
                await dbContext.Database.ExecuteSqlCommandAsync(MySetupClass.DropContstraintsSql);
                await dbContext.Database.ExecuteSqlCommandAsync(MySetupClass.DropTableSql);
            }

            DbConnection.Close();
        }
    }
}