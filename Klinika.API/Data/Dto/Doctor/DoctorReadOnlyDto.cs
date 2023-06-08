using Klinika.API.Data.Dto.Department;
namespace Klinika.API.Data.Dto.Doctor


{ 
	public class DoctorReadOnlyDto
	{
		public int DoctorID { get; set; }
		public string name { get; set; }
		public string lastname { get; set; }
		public string specialization { get; set; }
		public DepartmentReadOnlyDto Department { get; set; }
	}
}
