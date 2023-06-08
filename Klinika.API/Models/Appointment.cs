using System.ComponentModel.DataAnnotations;

namespace Klinika.API.Models
{
	public class Appointment
	{
		[Key]
		public int appointmentID { get; set; }

		public int patientID { get; set; }
		public required Patient Patient { get; set; }

		public required Doctor Doctor { get; set; } 
		public int doctorID { get; set; }

		public DateTime appointed_time { get; set; }
	}
}