using System.ComponentModel.DataAnnotations;

namespace Klinika.API.Models
{
	public class Diagnose
	{
		[Key]
		public int DiagnoseID { get; set; }
		public string name { get; set; } = string.Empty;
		public string description { get; set; } = string.Empty;

	}
}
