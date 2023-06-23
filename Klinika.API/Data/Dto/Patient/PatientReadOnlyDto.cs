using Klinika.API.Data.Dto.Department;
using Klinika.API.Data.Dto.Diagnose;

namespace Klinika.API.Data.Dto.Patient
{
	public class PatientReadOnlyDto
	{
	    public int patientID { get; set; }
        public string name { get; set; }
        public string lastname { get; set; }
        public DateTime date_of_birth { get; set; } 
       
	}
}
