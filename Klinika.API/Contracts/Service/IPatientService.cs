using Klinika.API.Data.Dto;
using Klinika.API.Data.Dto.Patient;

namespace Klinika.API.Contracts.Service
{
	public interface IPatientService
	{
		Task<IEnumerable<PatientReadOnlyDto>> GetAllPatients();
		Task<PatientReadOnlyDto> GetPatientById(int patientId);

		Task<ResponseDto> CreatePatient(PatientCreateDto patientDto);
		Task<ResponseDto> UpdatePatient(int patientId, PatientUpdateDto patientDto);
		Task<bool> DeletePatient(int patientId);
	}
}
