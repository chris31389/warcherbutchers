using System.Collections.Generic;
using System.Threading.Tasks;

namespace WArcherButchers.ServerApp.Infrastructure
{
    public interface IRepository<TEntity> 
        where TEntity : class, IEntity
    {
        Task<TEntity> Get(string id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> Save(TEntity entity);
        Task Delete(string id);
        Task Delete(TEntity entity);
    }
}