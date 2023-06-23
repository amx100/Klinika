using Klinika.API.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

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
		[Required]

		private string _status = AppointmentStatus.Pending.ToString();

		[Required]
		public string status
		{
			get { return _status; }
			set
			{
				AppointmentStatus appointmentStatus;
				if (Enum.TryParse(value, true, out appointmentStatus))
				{
					_status = appointmentStatus.ToString();
				}
				else
				{
					_status = AppointmentStatus.Pending.ToString();
				}
			}
		}

		public decimal price { get; set; }

	}
}
