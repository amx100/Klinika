using Klinika.API.Models;
using System.ComponentModel.DataAnnotations;

namespace Klinika.API.Data.Dto.Appointment
{
	public class AppointmentUpdateDto
	{
		public int appointmentID { get; set; }
		public DateTime appointmentDate { get; set; }
		public int patientID { get; set; }
		public int doctorID { get; set; }
		public AppointmentStatus status { get; set; }
	}
}
