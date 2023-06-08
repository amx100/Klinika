using Klinika.API.Data.Dto.Department;
using Klinika.API.Data.Dto.Diagnose;

namespace Klinika.API.Data.Dto.Patient
{
	public class PatientReadOnlyDto
	{
	    public int PatientID { get; set; }
        public string name { get; set; }
        public string lastname { get; set; }
        public int phone { get; set; }
        public DateTime date_of_birth { get; set; }
        public DepartmentReadOnlyDto Departmentent { get; set; } 
        public DiagnoseReadOnlyDto Diagnose {get; set; }
	}
}
