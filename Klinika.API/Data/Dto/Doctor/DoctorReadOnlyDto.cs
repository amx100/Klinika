using Klinika.API.Data.Dto.Department;
using Klinika.API.Data.Dto.Patient;

namespace Klinika.API.Data.Dto.Doctor
{
	public class DoctorReadOnlyDto
	{
		public int doctorID { get; set; }
		public string name { get; set; }
		public string lastname { get; set; }
		public string specialization { get; set; }
		public DepartmentReadOnlyDto Department { get; set; }
		//public List<PatientReadOnlyDto> Patients { get; set; } 
	}
}
