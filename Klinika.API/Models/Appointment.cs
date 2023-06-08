using System.ComponentModel.DataAnnotations;

namespace Klinika.API.Models
{
	public class Appointment
	{
		[Key]
		public int AppointmentID { get; set; }

		public int PatientID { get; set; }
		public required Patient Patient { get; set; }

		public required Doctor Doctor { get; set; } 
		public int DoctorID { get; set; }

		public DateTime appointed_time { get; set; }
	}
}