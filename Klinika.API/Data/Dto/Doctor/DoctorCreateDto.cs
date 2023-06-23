using System.ComponentModel.DataAnnotations;

namespace Klinika.API.Data.Dto.Doctor
{
    public class DoctorCreateDto
    {
       
        [Required]
        public string name { get; set; }
        [Required]
        public string lastname { get; set; }
        [Required]
        public string specialization { get; set; }
		[Required]
		public DateTime date_of_birth { get; set; }
		[Required]
		public int departmentID { get; set; }
	}
}
