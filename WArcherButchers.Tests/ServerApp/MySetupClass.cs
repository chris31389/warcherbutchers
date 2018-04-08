using System.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace WArcherButchers.Tests.ServerApp
{
    [SetUpFixture]
    public class MySetupClass
    {
        public const string DatabaseName = "WArcherTestDb";

        public const string DropContstraintsSql =
            " while(exists(select 1 from INFORMATION_SCHEMA.TABLE_CONSTRAINTS where CONSTRAINT_TYPE='FOREIGN KEY'))" +
            " begin" +
            "  declare @sql nvarchar(2000)" +
            "  SELECT TOP 1 @sql=('ALTER TABLE ' + TABLE_SCHEMA + '.[' + TABLE_NAME" +
            "  + '] DROP CONSTRAINT [' + CONSTRAINT_NAME + ']')" +
            "  FROM information_schema.table_constraints" +
            "  WHERE CONSTRAINT_TYPE = 'FOREIGN KEY'" +
            "  exec (@sql)" +
            "  PRINT @sql" +
            " end";

        public const string DropTableSql =
            " while(exists(select 1 from INFORMATION_SCHEMA.TABLES where TABLE_TYPE = 'BASE TABLE'))" +
            " begin" +
            "  declare @sql nvarchar(2000)" +
            "  SELECT TOP 1 @sql=('DROP TABLE ' + TABLE_SCHEMA + '.[' + TABLE_NAME" +
            "  + ']')" +
            "  FROM INFORMATION_SCHEMA.TABLES" +
            "  WHERE TABLE_TYPE = 'BASE TABLE'" +
            " exec (@sql)" +
            "  PRINT @sql" +
            " end";

        private static string ConnectionString => new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables()
            .Build()
            .GetConnectionString("Database");

        public static string TestDatabaseConnectionString => new SqlConnectionStringBuilder
        {
            ConnectionString = ConnectionString,
            InitialCatalog = DatabaseName
        }.ToString();

        [OneTimeTearDown]
        public async Task OneTimeTearDown()
        {
            await DropDatabaseAsync(ConnectionString);
        }

        public static async Task DropDatabaseAsync(string connectionString)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                using (SqlCommand command =
                    new SqlCommand($"ALTER DATABASE {DatabaseName} SET single_user with rollback immediate",
                        sqlConnection))
                {
                    await command.ExecuteNonQueryAsync();
                }

                using (SqlCommand command = new SqlCommand($"DROP DATABASE {DatabaseName}", sqlConnection))
                {
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}