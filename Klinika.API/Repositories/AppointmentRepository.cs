using Klinika.API.Contracts.Repositories;
using Klinika.API.Data;
using Klinika.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Klinika.API.Repositories
{
    public class AppointmentRepository : BaseRepository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(ApplicationDbContext context) : base(context) { }
        public void CreateAppointment(Appointment appointment) => Create(appointment);
        public void UpdateAppointment(Appointment appointment) => Update(appointment);
        public void DeleteAppointment(Appointment appointment) => Delete(appointment);
        public async Task<IEnumerable<Appointment>> GetAllAppointments() => await SelectAll().ToListAsync();
        public async Task<Appointment> GetAppointmentById(int appointmentId) => await SelectByCondition(appointment => appointment.AppointmentID == appointmentId).FirstOrDefaultAsync();


    }
}
