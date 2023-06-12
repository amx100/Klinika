namespace Klinika.API.Data.Dto.Diagnose
{
	public class DiagnoseUpdateDto
	{
		public int diagnoseID { get; set; }
		public string name { get; set; }
		public int? patientID { get; set; }
	}
}
