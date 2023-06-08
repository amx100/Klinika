using Klinika.API.Models;

namespace Klinika.API.Contracts.Repositories
{
    public interface IPatientRepository  : IBaseRepository<Patient>
    {
        Task<IEnumerable<Patient>> GetAllPatients();
        Task<Patient> GetPatientById(int patientId);
        void CreatePatient(Patient patient);
        void UpdatePatient(Patient patient);
        void DeletePatient(Patient patient);
    }
}
