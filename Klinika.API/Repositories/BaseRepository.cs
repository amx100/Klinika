using Klinika.API.Contracts.Repositories;
using Klinika.API.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Klinika.API.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(T entity) => _context.Set<T>().Add(entity);

        public void Update(T entity) => _context.Set<T>().Update(entity);

        public void Delete(T entity) => _context.Set<T>().Remove(entity);

        public IQueryable<T> SelectAll() => _context.Set<T>().AsNoTracking();

        public IQueryable<T> SelectByCondition(Expression<Func<T, bool>> expression) => _context.Set<T>().Where(expression).AsNoTracking();
    }
}
