using Klinika.API.Data.Dto.Doctor;
using Klinika.API.Data.Dto.Patient;
using System.ComponentModel.DataAnnotations;

namespace Klinika.API.Data.Dto.Appointment
{
	public class AppointmentReadOnlyDto
	{
		[Required]
		public int appointmentID { get; set; }
		public PatientReadOnlyDto Patient { get; set; }
		public DoctorReadOnlyDto Doctor { get; set; }
		public DateTime appointed_time { get; set; }
	}
}
