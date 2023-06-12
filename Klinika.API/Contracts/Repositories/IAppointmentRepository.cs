using Klinika.API.Models;

namespace Klinika.API.Contracts.Repositories
{
    public interface IAppointmentRepository : IBaseRepository<Appointment>
    {
        Task<IEnumerable<Appointment>> GetAllAppointments();
        Task<Appointment> GetAppointmentById(int appointmentId);
		Task<IEnumerable<Appointment>> GetAppointmentByDoctorId(int doctorId);
		void CreateAppointment(Appointment appointment);
        void UpdateAppointment(Appointment appointment);
        void DeleteAppointment(Appointment appointment);
    }
    
}
