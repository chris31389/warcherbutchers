namespace WArcherButchers.ServerApp.Infrastructure.Data.DbContexts
{
    public interface IWArcherDbContextFactory
    {
        WArcherDbContext CreateDbContext();
    }
}