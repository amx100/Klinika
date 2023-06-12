using Klinika.API.Models;
using System.ComponentModel.DataAnnotations;

namespace Klinika.API.Data.Dto.Appointment
{
	public class AppointmentCreateDto
	{
		[Required]
		public DateTime appointmentDate { get; set; }
		[Required]
		public int patientID { get; set; }
		[Required]
		public int doctorID { get; set; }
		public AppointmentStatus status { get; set; } = AppointmentStatus.Pending;

	}
}
