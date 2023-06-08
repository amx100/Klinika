using System.ComponentModel.DataAnnotations;

namespace Klinika.API.Data.Dto.Appointment
{
	public class AppointmentUpdateDto
	{
		public int appointmentID { get; set; }
		public DateTime appointed_time { get; set; }
		public int patientID { get; set; }
		public int doctorID { get; set; }
	}
}
