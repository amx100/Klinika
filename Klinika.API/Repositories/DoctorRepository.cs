using Klinika.API.Contracts.Repositories;
using Klinika.API.Data;
using Klinika.API.Models;
using Klinika.API.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Application.Repositories
{
	public class DoctorRepository : BaseRepository<Doctor>, IDoctorRepository
	{
		public DoctorRepository(ApplicationDbContext context) : base(context) { }

		public void CreateDoctor(Doctor doctor) => Create(doctor);
		public void UpdateDoctor(Doctor doctor) => Update(doctor);
		public void DeleteDoctor(Doctor doctor) => Delete(doctor);

		public async Task<IEnumerable<Doctor>> GetAllDoctors()
		{
			return await SelectAll().Include(d => d.Department).ToListAsync();
		}

		public async Task<Doctor> GetDoctorById(int doctorId)
		{
			return await SelectByCondition(d => d.doctorID == doctorId).Include(d => d.Department).FirstOrDefaultAsync();
		}
	}

}
