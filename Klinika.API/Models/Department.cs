using System.ComponentModel.DataAnnotations;

namespace Klinika.API.Models
{
    public class Department
    {
        [Key]   
        public int departmentID { get; set; }
        public string name { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;

    }
}
