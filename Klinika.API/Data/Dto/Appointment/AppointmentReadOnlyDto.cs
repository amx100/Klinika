using Klinika.API.Data.Dto.Department;
using Klinika.API.Data.Dto.Doctor;
using Klinika.API.Data.Dto.Patient;
using Klinika.API.Models;
using System.ComponentModel.DataAnnotations;

namespace Klinika.API.Data.Dto.Appointment
{
	public class AppointmentReadOnlyDto
	{
		public int appointmentID { get; set; }
		public PatientReadOnlyDto? Patient { get; set; }
		public DoctorReadOnlyDto? Doctor { get; set; }
		public DateTime appointmentDate { get; set; }
		public decimal price { get; set; }
		//public string status { get; set; }

		//public AppointmentStatus AppointmentStatus
		//{
		//	get { return Enum.Parse<AppointmentStatus>(status); }
		//	set { status = value.ToString(); }
		//}

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
	}


}
