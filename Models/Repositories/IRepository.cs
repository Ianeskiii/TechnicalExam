using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace technicalExam.Models.Repositories
{
    public interface IRepository
    {
         Task<List<T>> FindByCondition<T>(Expression<Func<T, bool>> expression) where T : class;
         Task CreateAsync<T>(T entity) where T : class;
    }
}
