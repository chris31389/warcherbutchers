namespace WArcherButchers.ServerApp.Infrastructure.Data.DbContexts
{
    /// <summary>
    /// A Database Connection String Provider
    /// </summary>
    public interface IDatabaseConnectionStringProvider
    {
        /// <summary>
        /// Provides the Connection String
        /// </summary>
        /// <returns>Database Connection String</returns>
        string Get();
    }
}