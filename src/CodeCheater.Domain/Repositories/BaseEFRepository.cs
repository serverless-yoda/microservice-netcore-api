using CodeCheater.Domain.Context;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace CodeCheater.Domain.Repositories
{
    public class BaseEFRepository<T> : IBaseEFRepository<T> where T : Entity
    {
        private readonly EFContext db;
        public BaseEFRepository(EFContext db)
        {
            this.db = db;
        }

        public async Task<T> AddAsync(T entity)
        {
            await this.db.Set<T>().AddAsync(entity);
            await SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
              this.db.Set<T>().Remove(entity);
               await SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await this.db.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await this.db.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null, 
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, 
            string includedString = null, 
            bool disableTracking = true)
        {
            IQueryable<T> query = this.db.Set<T>();
            if(disableTracking)
            {
                query = query.AsNoTracking();
            }
            if(predicate != null)
            {
                query = query.Where(predicate);
            }
            if (!string.IsNullOrEmpty(includedString))
            {
                query = query.Include(includedString);
            }

            if(orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            return await query.ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null, 
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, 
            List<Expression<Func<T, object>>> includes = null, 
            bool disableTracking = true)
        {
            IQueryable<T> query = this.db.Set<T>();
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
           

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            return await query.ToListAsync();
        }

        public async  Task<T> GetByIdAsync(int id)
        {
            return await this.db.Set<T>().FindAsync(id);
        }

        public async Task SaveChangesAsync()
        {
            await this.db.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            await this.SaveChangesAsync();
        }

      
    }
}
