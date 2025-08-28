using ApplicationCore.Contracts.Repository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class BaseRepsitory<T> : IRepository<T> where T: class
    {
        protected readonly MovieShopDbContext _dbContext;
        public BaseRepsitory(MovieShopDbContext db)
        {
            _dbContext = db;   
        }
        public virtual T DeleteById(int id)
        {
            var entity = _dbContext.Set<T>().Find(id);

            if(entity != null)
            {
                _dbContext.Set<T>().Remove(entity);
                _dbContext.SaveChanges();
                return entity;
            }

            return null;
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _dbContext.Set<T>().AsNoTracking().ToList();
        }

        public virtual async Task<T?> GetById(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public virtual T Insert(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public virtual T Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return entity;
        }
    }
}
