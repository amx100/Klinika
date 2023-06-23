namespace Klinika.API.Data.Dto.Doctor
{
    public class DoctorUpdateDto
    {
        public int doctorID { get; set; }
        public string name { get; set; }
        public string lastname { get; set; }
        public string specialization { get; set; }
		public DateTime date_of_birth { get; set; }
		public int departmentID { get; set; }
    }
}
