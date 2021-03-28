using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Versatil.Data.Extensions;
using Versatil.Domain.Entities;
using Versatil.Domain.Interfaces.Repositories;

namespace Versatil.Data.Repositories
{
    public class EFRepositoryBase<TEntity, Context> : IRepositoryBase<TEntity>
        where TEntity : Entity
        where Context : DbContext
    {

        protected readonly Context DbContext;
        protected readonly DbSet<TEntity> Entity;

        protected EFRepositoryBase(Context applicationDbContext)
        {
            DbContext = applicationDbContext;
            Entity = DbContext.Set<TEntity>();
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            Entity.Add(entity);
            await DbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            Entity.Update(entity);
            await DbContext.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(int id)
        {
            var item = Entity.Find(id);
            DbContext.Remove(item);
            await DbContext.SaveChangesAsync();
        }

        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> expressionSearch, Expression<Func<TEntity, object>>[] expressionIncludes = null)
        {
            var query = Entity as IQueryable<TEntity>;
            query = query.AddIncludes(expressionIncludes);
            return await query.FirstOrDefaultAsync(expressionSearch);
        }

        public async Task<IEnumerable<TEntity>> GetMany(Expression<Func<TEntity, bool>> expressionSearch, Expression<Func<TEntity, object>>[] expressionIncludes = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            var query = Entity as IQueryable<TEntity>;
            query = query.AddIncludes(expressionIncludes);

            query = query.Where(expressionSearch);

            if (orderBy != null){
                return await orderBy(query).ToListAsync();
            }

            return await query.ToListAsync();
        }


    }
}