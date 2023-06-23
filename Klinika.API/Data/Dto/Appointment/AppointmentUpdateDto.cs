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

		private string _status = AppointmentStatus.Pending.ToString();
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
		//public AppointmentStatus AppointmentStatus
		//{
		//	get { return Enum.Parse<AppointmentStatus>(status); }
		//	set { status = value.ToString(); }
		//}
		public decimal price { get; set; }
	}

}
