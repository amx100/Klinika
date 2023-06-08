using Klinika.API.Data.Dto.Department;
using Klinika.API.Data.Dto;

namespace Klinika.API.Contracts.Service
{
	public interface IDepartmentService
	{
		Task<IEnumerable<DepartmentReadOnlyDto>> GetAllDepartments();
		Task<DepartmentReadOnlyDto> GetDepartmentById(int departmentId);
		Task<ResponseDto> CreateDepartment(DepartmentCreateDto departmentDto);
		Task<ResponseDto> UpdateDepartment(int departmentId, DepartmentUpdateDto departmentDto);
		Task<bool> DeleteDepartment(int departmentId);
	}
}
