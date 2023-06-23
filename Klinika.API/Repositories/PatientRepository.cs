using Klinika.API.Contracts.Repositories;
using Klinika.API.Data;
using Klinika.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Klinika.API.Repositories
{
    public class PatientRepository : BaseRepository<Patient>, IPatientRepository
    {
        public PatientRepository(ApplicationDbContext context) : base(context){ }
        public void CreatePatient(Patient patient) => Create(patient);
        public void UpdatePatient(Patient patient) => Update(patient);
        public void DeletePatient(Patient patient) => Delete(patient);
		public async Task<IEnumerable<Patient>> GetAllPatients()
		{
			return await SelectAll().ToListAsync();
		}

		public async Task<Patient> GetPatientById(int patientId)
		{
			return await SelectByCondition(p => p.patientID == patientId).FirstOrDefaultAsync();
		}


	}
}
