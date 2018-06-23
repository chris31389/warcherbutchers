using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WArcherButchers.ServerApp.Infrastructure.Entities;

namespace WArcherButchers.ServerApp.Infrastructure
{
    public interface IRepository<T> where T : class, IEntity
    {
        Task<IEnumerable<T>> GetAllAsync(IEnumerable<Guid> entityIds);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(Guid id);
        Task SaveAsync(T domainEntity);
        Task SaveAllAsync(IEnumerable<T> entities);
        Task<bool> RemoveAsync(Guid id);
    }
}