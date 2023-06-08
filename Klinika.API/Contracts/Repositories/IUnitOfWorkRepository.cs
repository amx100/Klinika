namespace Klinika.API.Contracts.Repositories
{
    public interface IUnitOfWorkRepository
    {
        Task<int> SaveChangesAsync();
    }
}