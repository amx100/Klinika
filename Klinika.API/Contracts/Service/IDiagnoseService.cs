using Klinika.API.Data.Dto.Diagnose;
using Klinika.API.Data.Dto;

namespace Klinika.API.Contracts.Service
{
	public interface IDiagnoseService
	{
		Task<IEnumerable<DiagnoseReadOnlyDto>> GetAllDiagnoses();
		Task<DiagnoseReadOnlyDto> GetDiagnoseById(int diagnoseId);
		Task<ResponseDto> CreateDiagnose(DiagnoseCreateDto diagnoseDto);
		Task<ResponseDto> UpdateDiagnose(int diagnoseId, DiagnoseUpdateDto diagnoseDto);
		Task<bool> DeleteDiagnose(int diagnoseId);
	}
}
