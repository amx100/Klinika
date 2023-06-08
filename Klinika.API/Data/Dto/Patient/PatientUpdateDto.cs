namespace Klinika.API.Data.Dto.Patient
{
	public class PatientUpdateDto
	{
		public int PatientID { get; set; }
		public string name { get; set; }
		public string lastname { get; set; }
		public int phone { get; set; }
		public DateTime date_of_birth { get; set; }
	}
}
