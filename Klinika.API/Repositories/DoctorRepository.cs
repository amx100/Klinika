using Klinika.API.Contracts.Repositories;
using Klinika.API.Data;
using Klinika.API.Models;
using Klinika.API.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Application.Repositories
{
    public class DoctorRepository : BaseRepository<Doctor>, IDoctorRepository
    { 
        public DoctorRepository(ApplicationDbContext context) : base(context) {}

        public void CreateDoctor(Doctor doctor) => Create(doctor);
        public void UpdateDoctor(Doctor doctor) => Update(doctor);
        public void DeleteDoctor(Doctor doctor) => Delete(doctor);
        public async Task<Doctor> GetDoctorById(int doctorId) => await SelectByCondition(doctor => doctor.DoctorID == doctorId).FirstOrDefaultAsync();
        public async Task<IEnumerable<Doctor>> GetAllDoctors() => await SelectAll().ToListAsync();
    }
}
