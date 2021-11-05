using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace technicalExam.Models.Repositories
{
    public class Repository<TDbContext> : IRepository where TDbContext : DbContext
    {
        protected TDbContext dbContext;

        public Repository(TDbContext context)
        {
            dbContext = context;
        }
        public async Task<List<T>> FindByCondition<T>(Expression<Func<T, bool>> expression) where T : class
        {
            return await this.dbContext.Set<T>().Where(expression).ToListAsync(); 
        }

        public async Task CreateAsync<T>(T entity) where T : class
        {
            this.dbContext.Set<T>().Add(entity);

            _ = await this.dbContext.SaveChangesAsync();
        }
    }
}
