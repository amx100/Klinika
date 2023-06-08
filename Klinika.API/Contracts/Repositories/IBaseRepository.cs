using System.Linq.Expressions;

namespace Klinika.API.Contracts.Repositories
{
    public interface IBaseRepository<T>
    {
        IQueryable<T> SelectAll();
        IQueryable<T> SelectByCondition(Expression<Func<T, bool>> expression);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
