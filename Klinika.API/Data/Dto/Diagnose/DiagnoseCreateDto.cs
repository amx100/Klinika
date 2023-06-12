using System.ComponentModel.DataAnnotations;

namespace Klinika.API.Data.Dto.Diagnose
{
	public class DiagnoseCreateDto
	{
		[Required]
		public string name { get; set; }
		public string description { get; set; }
		public int patientID { get; set; }

	}
}
