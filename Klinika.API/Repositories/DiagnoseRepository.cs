using Klinika.API.Contracts.Repositories;
using Klinika.API.Data;
using Klinika.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Klinika.API.Repositories
{
    public class DiagnoseRepository : BaseRepository<Diagnose>, IDiagnoseRepository
    {
        public DiagnoseRepository(ApplicationDbContext context) : base(context) {}
        public void CreateDiagnose(Diagnose diagnose) => Create(diagnose);
        public void UpdateDiagnose(Diagnose diagnose) => Update(diagnose);
        public void DeleteDiagnose(Diagnose diagnose) => Delete(diagnose);
        public async Task<Diagnose> GetDiagnoseById(int diagnoseId) => await SelectByCondition(diagnose => diagnose.diagnoseID == diagnoseId).FirstOrDefaultAsync();
        public async Task<IEnumerable<Diagnose>> GetAllDiagnoses() => await SelectAll().ToListAsync();

       
    }
}
