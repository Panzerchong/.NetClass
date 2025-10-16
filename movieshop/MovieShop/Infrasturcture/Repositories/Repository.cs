using ApplicationCore.Contracts.Repositories;
using Infrasturcture.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrasturcture.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly MovieShopDbContext _dbContext;
        public Repository(MovieShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async virtual Task<T> Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);//保存在内存里，没有保存到数据库
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async virtual Task<T> Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public async virtual Task<IEnumerable<T>> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async virtual Task<T> GetById(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public virtual Task<T> Update(T entity)
        {
            throw new NotImplementedException();
        }
    }


}
