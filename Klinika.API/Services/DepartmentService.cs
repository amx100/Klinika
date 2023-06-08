using Klinika.API.Contracts.Repositories;
using Klinika.API.Contracts.Service;
using Klinika.API.Data.Dto.Department;
using Klinika.API.Data.Dto;
using Klinika.API.Models;
using Mapster;

namespace Klinika.API.Services
{
	public class DepartmentService : IDepartmentService
	{
		private readonly IRepositoryManager _repositoryManager;
		private readonly ResponseDto _response;


		public DepartmentService(IRepositoryManager repositoryManager)
		{
			_repositoryManager = repositoryManager;
			_response = new();
		}


		public async Task<ResponseDto> CreateDepartment(DepartmentCreateDto departmentDto)
		{
			var department = departmentDto.Adapt<Department>();
			_repositoryManager.DepartmentRepository.CreateDepartment(department);
			var result = await _repositoryManager.UnitOfWorkRepository.SaveChangesAsync();
			if (result > 0)
			{
				_response.Data = department;
				return _response;
			}

			_response.IsSuccess = false;
			_response.DisplayMessage = "Error Creating Department";
			return _response;
		}

		public async Task<ResponseDto> UpdateDepartment(int departmentId, DepartmentUpdateDto departmentDto)
		{
			var departmentCheck = await _repositoryManager.DepartmentRepository.GetDepartmentById(departmentId);
			if (departmentCheck is null)
			{
				_response.IsSuccess = false;
				_response.DisplayMessage = "Department not found in Database";
				return _response;
			}
			var department = departmentDto.Adapt<Department>();
			_repositoryManager.DepartmentRepository.Update(department);

			var result = await _repositoryManager.UnitOfWorkRepository.SaveChangesAsync();
			if (result > 0)
			{
				_response.Data = department;
				return _response;
			}

			_response.IsSuccess = false;
			_response.DisplayMessage = "Error Updating Department";
			return _response;
		}

		public async Task<bool> DeleteDepartment(int departmentId)
		{
			var department = await _repositoryManager.DepartmentRepository.GetDepartmentById(departmentId);
			if (department is not null)
			{
				_repositoryManager.DepartmentRepository.DeleteDepartment(department);
				return await _repositoryManager.UnitOfWorkRepository.SaveChangesAsync() == 1;
			}

			return false;
		}


		public async Task<IEnumerable<DepartmentReadOnlyDto>> GetAllDepartments()
		{
			var departments = await _repositoryManager.DepartmentRepository.GetAllDepartments();
			return departments.Adapt<IEnumerable<DepartmentReadOnlyDto>>();
		}

		public async Task<DepartmentReadOnlyDto> GetDepartmentById(int departmentId)
		{
			var department = await _repositoryManager.DepartmentRepository.GetDepartmentById(departmentId);
			return department.Adapt<DepartmentReadOnlyDto>();
		}
	}
}
