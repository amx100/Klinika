namespace Klinika.API.Services
{
	using Klinika.API.Contracts.Repositories;
	using Klinika.API.Contracts.Services;
	using Klinika.API.Data.Dto;
	using Klinika.API.Data.Dto.Doctor;
	using Klinika.API.Models;
	using Mapster;

	namespace Application.Services
	{
		public class DoctorService : IDoctorService
		{
			private readonly IRepositoryManager _repositoryManager;
			private readonly ResponseDto _response;
			

			public DoctorService(IRepositoryManager repositoryManager)
			{
				_repositoryManager = repositoryManager;
				_response = new();
			}


			public async Task<ResponseDto> CreateDoctor(DoctorCreateDto doctorDto)
			{
				var doctor = doctorDto.Adapt<Doctor>();
				_repositoryManager.DoctorRepository.CreateDoctor(doctor);
				var result = await _repositoryManager.UnitOfWorkRepository.SaveChangesAsync();
				if (result > 0)
				{
					_response.Data = doctor;
					return _response;
				}

				_response.IsSuccess = false;
				_response.DisplayMessage = "Error Creating Doctor";
				return _response;
			}

			public async Task<ResponseDto> UpdateDoctor(int doctorId, DoctorUpdateDto doctorDto)
			{
				var doctorCheck = await _repositoryManager.DoctorRepository.GetDoctorById(doctorId);
				if (doctorCheck is null)
				{
					_response.IsSuccess = false;
					_response.DisplayMessage = "Doctor not found in Database";
					return _response;
				}
				var doctor = doctorDto.Adapt<Doctor>();
				_repositoryManager.DoctorRepository.Update(doctor);

				var result = await _repositoryManager.UnitOfWorkRepository.SaveChangesAsync();
				if (result > 0)
				{
					_response.Data = doctor;
					return _response;
				}

				_response.IsSuccess = false;
				_response.DisplayMessage = "Error Updating Doctor";
				return _response;
			}

			public async Task<bool> DeleteDoctor(int doctorId)
			{
				var doctor = await _repositoryManager.DoctorRepository.GetDoctorById(doctorId);
				if (doctor is not null)
				{
					_repositoryManager.DoctorRepository.DeleteDoctor(doctor);
					return await _repositoryManager.UnitOfWorkRepository.SaveChangesAsync() == 1;
				}

				return false;
			}


			public async Task<IEnumerable<DoctorReadOnlyDto>> GetAllDoctors()
			{
				var doctors = await _repositoryManager.DoctorRepository.GetAllDoctors();
				return doctors.Adapt<IEnumerable<DoctorReadOnlyDto>>();
			}

			public async Task<DoctorReadOnlyDto> GetDoctorById(int doctorId)
			{
				var doctor = await _repositoryManager.DoctorRepository.GetDoctorById(doctorId);
				return doctor.Adapt<DoctorReadOnlyDto>();
			}

			
		}
	}
}
