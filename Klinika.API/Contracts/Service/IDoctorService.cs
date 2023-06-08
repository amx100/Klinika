using Klinika.API.Data.Dto;
using Klinika.API.Data.Dto.Doctor;

namespace Klinika.API.Contracts.Services
{
    public interface IDoctorService
    {
		Task<IEnumerable<DoctorReadOnlyDto>> GetAllDoctors();
		Task<DoctorReadOnlyDto> GetDoctorById(int doctorId);
        Task<ResponseDto> CreateDoctor(DoctorCreateDto doctorDto);
        Task<ResponseDto> UpdateDoctor(int doctorId, DoctorUpdateDto doctorDto);
        Task<bool> DeleteDoctor(int doctorId);
		
		
	}
}
