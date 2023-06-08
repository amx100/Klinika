using Klinika.API.Models;

namespace Klinika.API.Contracts.Repositories
{
    public interface IDiagnoseRepository : IBaseRepository<Diagnose>
    {
        Task<IEnumerable<Diagnose>> GetAllDiagnoses();
        Task<Diagnose> GetDiagnoseById(int diagnoseId);
        void CreateDiagnose(Diagnose diagnose);
        void UpdateDiagnose(Diagnose diagnose);
        void DeleteDiagnose(Diagnose diagnose);
    }
}
