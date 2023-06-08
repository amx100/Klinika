using System.ComponentModel.DataAnnotations;

namespace Klinika.API.Data.Dto.Appointment
{
	public class AppointmentCreateDto
	{
		[Required]
		public DateTime appointed_time { get; set; }
		[Required]
		public int patientID { get; set; }
		[Required]
		public int doctorID { get; set; }

	}
}
