using System.ComponentModel.DataAnnotations;

namespace Klinika.API.Data.Dto.Department
{
	public class DepartmentCreateDto
	{
		[Required]
		public string name { get; set; }
		
	}
}

