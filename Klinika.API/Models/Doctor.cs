using System.ComponentModel.DataAnnotations;

namespace Klinika.API.Models
{
	public class Doctor
	{
		[Key]
		public int doctorID { get; set; }
		public string name { get; set; } = string.Empty;
		public string lastname { get; set; } = string.Empty;
		public string specialization { get; set; } = string.Empty;
		public int departmentID { get; set; }
		public Department Department { get; set; }
	
	}

}
