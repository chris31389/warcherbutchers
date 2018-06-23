using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WArcherButchers.ServerApp.Infrastructure.Entities;

namespace WArcherButchers.ServerApp.Infrastructure.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly DbContext _dbContext;

        protected virtual IQueryable<T> CollectionQuery => _dbContext.Set<T>();

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<IEnumerable<T>> GetAllAsync(IEnumerable<Guid> entityIds) => await CollectionQuery
            .Where(x => entityIds.Contains(x.Id))
            .ToListAsync();

        public virtual async Task<IEnumerable<T>> GetAllAsync() => await CollectionQuery.ToListAsync();

        public virtual async Task<T> GetAsync(Guid id) => await CollectionQuery.FirstOrDefaultAsync(x => x.Id == id);

        public virtual async Task SaveAsync(T domainEntity)
        {
            if (domainEntity == null)
            {
                throw new ArgumentNullException(nameof(domainEntity));
            }

            Guid existingEntityId = await _dbContext
                .Set<T>()
                .AsNoTracking()
                .Where(x => x.Id == domainEntity.Id)
                .Select(x => x.Id)
                .FirstOrDefaultAsync();

            if (existingEntityId == default(Guid))
            {
                _dbContext.Set<T>().Add(domainEntity);
            }
            else if (_dbContext.Set<T>().Local.All(e => e != domainEntity))
            {
                _dbContext.Update(domainEntity);
            }

            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task SaveAllAsync(IEnumerable<T> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException(nameof(entities));
            }

            List<T> entityList = entities as List<T> ?? entities.ToList();
            IEnumerable<Guid> entityListIds = entityList.Select(x => x.Id);
            List<Guid> existingEntityIds = await _dbContext.Set<T>().AsNoTracking()
                .Where(x => entityListIds.Contains(x.Id))
                .Select(x => x.Id)
                .ToListAsync();

            entityList
                .ForEach(entity =>
                {
                    if (!existingEntityIds.Contains(entity.Id))
                    {
                        _dbContext.Add(entity);
                    }
                    else if (_dbContext.Set<T>().Local.All(e => e != entity))
                    {
                        _dbContext.Update(entity);
                    }
                });

            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task<bool> RemoveAsync(Guid id)
        {
            T entity = await CollectionQuery.FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null)
            {
                return false;
            }

            _dbContext
                .Set<T>()
                .Remove(entity);
            return true;
        }
    }
}