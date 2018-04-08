namespace WArcherButchers.ServerApp.Infrastructure.Data.DbContexts
{
    public interface IDatabase
    {
        string ConnectionString { get; }
    }
}