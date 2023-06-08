using Klinika.API.Models;

namespace Klinika.API.Contracts.Repositories
{
    public interface IDoctorRepository : IBaseRepository<Doctor>
    {
        Task<IEnumerable<Doctor>> GetAllDoctors();
        Task<Doctor> GetDoctorById(int doctorId);
        void CreateDoctor(Doctor doctor);
        void UpdateDoctor(Doctor doctor);
        void DeleteDoctor(Doctor doctor);
        
    }
}
