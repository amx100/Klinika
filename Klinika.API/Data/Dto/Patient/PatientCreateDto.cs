using System.ComponentModel.DataAnnotations;

namespace Klinika.API.Data.Dto.Patient
{
	public class PatientCreateDto
	{
		[Required]
		public string name { get; set; }
		[Required]
		public string lastname { get; set; }
		[Required]
		public DateTime date_of_birth { get; set; }	
	}
}
