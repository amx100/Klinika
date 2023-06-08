using System.ComponentModel.DataAnnotations;

namespace Klinika.API.Models
{
	public class Patient
	{
		[Key]
		public int patientID { get; set; }
		public string name { get; set; } = string.Empty;
		public string lastname { get; set; } = string.Empty;
		public int phone { get; set; }
		public DateTime date_of_birth { get; set; }

		public required Department Department { get; set; }
		public int departmentID { get; set; }

		public required Diagnose Diagnose { get; set; }
		public int diagnoseID { get; set; }
		
	}
}
