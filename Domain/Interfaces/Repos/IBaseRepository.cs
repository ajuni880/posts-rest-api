using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PostsAPI.Domain.Interfaces.Repos
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> FindAsync(int id);
        Task<IList<T>> ListAsync();
        IList<T> List(Expression<Func<T, bool>> expression);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
