using Microsoft.EntityFrameworkCore;
using WArcherButchers.ServerApp.Infrastructure.Data.Repositories;

namespace WArcherButchers.Tests.ServerApp.Infrastructure.Entities
{
    public class TestEntityRepository : Repository<TestEntity>
    {
        public TestEntityRepository(
            DbContext dbContext
        ) : base(dbContext)
        {
        }
    }
}