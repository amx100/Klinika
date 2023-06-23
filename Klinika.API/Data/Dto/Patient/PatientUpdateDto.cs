namespace Klinika.API.Data.Dto.Patient
{
	public class PatientUpdateDto
	{
		public int patientID { get; set; }
		public string name { get; set; }
		public string lastname { get; set; }
		public DateTime date_of_birth { get; set; }
	}
}
