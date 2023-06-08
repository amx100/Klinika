using Klinika.API.Contracts.Repositories;
using Klinika.API.Contracts.Service;
using Klinika.API.Data.Dto;
using Klinika.API.Data.Dto.Diagnose;
using Klinika.API.Models;
using Mapster;

namespace Klinika.API.Services
{

	public class DiagnoseService : IDiagnoseService
		{
			private readonly IRepositoryManager _repositoryManager;
			private readonly ResponseDto _response;


			public DiagnoseService(IRepositoryManager repositoryManager)
			{
				_repositoryManager = repositoryManager;
				_response = new();
			}


			public async Task<ResponseDto> CreateDiagnose(DiagnoseCreateDto diagnoseDto)
			{
				var diagnose = diagnoseDto.Adapt<Diagnose>();
				_repositoryManager.DiagnoseRepository.CreateDiagnose(diagnose);
				var result = await _repositoryManager.UnitOfWorkRepository.SaveChangesAsync();
				if (result > 0)
				{
					_response.Data = diagnose;
					return _response;
				}

				_response.IsSuccess = false;
				_response.DisplayMessage = "Error Creating Diagnose";
				return _response;
			}

			public async Task<ResponseDto> UpdateDiagnose(int diagnoseId, DiagnoseUpdateDto diagnoseDto)
			{
				var diagnoseCheck = await _repositoryManager.DiagnoseRepository.GetDiagnoseById(diagnoseId);
				if (diagnoseCheck is null)
				{
					_response.IsSuccess = false;
					_response.DisplayMessage = "Diagnose not found in Database";
					return _response;
				}
				var diagnose = diagnoseDto.Adapt<Diagnose>();
				_repositoryManager.DiagnoseRepository.Update(diagnose);

				var result = await _repositoryManager.UnitOfWorkRepository.SaveChangesAsync();
				if (result > 0)
				{
					_response.Data = diagnose;
					return _response;
				}

				_response.IsSuccess = false;
				_response.DisplayMessage = "Error Updating Diagnose";
				return _response;
			}

			public async Task<bool> DeleteDiagnose(int diagnoseId)
			{
				var diagnose = await _repositoryManager.DiagnoseRepository.GetDiagnoseById(diagnoseId);
				if (diagnose is not null)
				{
					_repositoryManager.DiagnoseRepository.DeleteDiagnose(diagnose);
					return await _repositoryManager.UnitOfWorkRepository.SaveChangesAsync() == 1;
				}

				return false;
			}


			public async Task<IEnumerable<DiagnoseReadOnlyDto>> GetAllDiagnoses()
			{
				var diagnoses = await _repositoryManager.DiagnoseRepository.GetAllDiagnoses();
				return diagnoses.Adapt<IEnumerable<DiagnoseReadOnlyDto>>();
			}

			public async Task<DiagnoseReadOnlyDto> GetDiagnoseById(int diagnoseId)
			{
				var diagnose = await _repositoryManager.DiagnoseRepository.GetDiagnoseById(diagnoseId);
				return diagnose.Adapt<DiagnoseReadOnlyDto>();
			}


		}
	}

