namespace Klinika.API.Services

{
	using global::Klinika.API.Contracts.Repositories;
	using global::Klinika.API.Contracts.Service;
	using global::Klinika.API.Data.Dto;
	using global::Klinika.API.Models;
	using Klinika.API.Data.Dto.Patient;
	using Mapster;

	namespace Application.Services
	{
		public class PatientService : IPatientService
		{
			private readonly IRepositoryManager _repositoryManager;
			private readonly ResponseDto _response;


			public PatientService(IRepositoryManager repositoryManager)
			{
				_repositoryManager = repositoryManager;
				_response = new();
			}


			public async Task<ResponseDto> CreatePatient(PatientCreateDto patientDto)
			{
				var patient = patientDto.Adapt<Patient>();
				_repositoryManager.PatientRepository.CreatePatient(patient);
				var result = await _repositoryManager.UnitOfWorkRepository.SaveChangesAsync();
				if (result > 0)
				{
					_response.Data = patient;
					return _response;
				}

				_response.IsSuccess = false;
				_response.DisplayMessage = "Error Creating Patient";
				return _response;
			}

			public async Task<ResponseDto> UpdatePatient(int patientId, PatientUpdateDto patientDto)
			{
				var patientCheck = await _repositoryManager.PatientRepository.GetPatientById(patientId);
				if (patientCheck is null)
				{
					_response.IsSuccess = false;
					_response.DisplayMessage = "Patient not found in Database";
					return _response;
				}
				var patient = patientDto.Adapt<Patient>();
				_repositoryManager.PatientRepository.Update(patient);

				var result = await _repositoryManager.UnitOfWorkRepository.SaveChangesAsync();
				if (result > 0)
				{
					_response.Data = patient;
					return _response;
				}

				_response.IsSuccess = false;
				_response.DisplayMessage = "Error Updating Patient";
				return _response;
			}

			public async Task<bool> DeletePatient(int patientId)
			{
				var patient = await _repositoryManager.PatientRepository.GetPatientById(patientId);
				if (patient is not null)
				{
					_repositoryManager.PatientRepository.DeletePatient(patient);
					return await _repositoryManager.UnitOfWorkRepository.SaveChangesAsync() == 1;
				}

				return false;
			}


			public async Task<IEnumerable<PatientReadOnlyDto>> GetAllPatients()
			{
				var patients = await _repositoryManager.PatientRepository.GetAllPatients();
				return patients.Adapt<IEnumerable<PatientReadOnlyDto>>();
			}

			public async Task<PatientReadOnlyDto> GetPatientById(int patientId)
			{
				var patient = await _repositoryManager.PatientRepository.GetPatientById(patientId);
				return patient.Adapt<PatientReadOnlyDto>();
			}


		}
	}
}
