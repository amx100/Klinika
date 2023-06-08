using Klinika.API.Contracts.Repositories;
using Klinika.API.Data;

namespace Klinika.API.Repositories
{
    public class UnitOfWorkRepository : IUnitOfWorkRepository
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWorkRepository(ApplicationDbContext context) => _context = context;

        public Task<int> SaveChangesAsync() => _context.SaveChangesAsync();
    }
}