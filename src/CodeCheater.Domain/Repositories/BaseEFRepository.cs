using CodeCheater.Domain.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
            return entity;
        }

        public void DeleteAsync(T entity)
        {
             this.db.Set<T>().Remove(entity);
        }

        public Task<IReadOnlyList<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includedString = null, bool disableTracking = true)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<Expression<Func<T, object>>> includes = null, bool disableTracking = true)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }

      
    }
}
