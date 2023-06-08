using Klinika.API.Contracts.Service;
using Klinika.API.Data.Dto.Department;
using Microsoft.AspNetCore.Mvc;

namespace Klinika.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DepartmentController : ControllerBase
	{
		private readonly IServiceManager _serviceManager;

		public DepartmentController(IServiceManager serviceManager)
		{
			_serviceManager = serviceManager;
		}

		[HttpGet]
		public async Task<IActionResult> GetDepartments()
		{
			var response = await _serviceManager.DepartmentService.GetAllDepartments();
			return Ok(response);
		}

		[HttpGet("{departmentId}")]
		public async Task<IActionResult> GetDepartmentById(int departmentId)
		{
			var response = await _serviceManager.DepartmentService.GetDepartmentById(departmentId);
			if (response is not null)
				return Ok(response);
			return NotFound("Department not found.");
		}

		[HttpPost]
		public async Task<IActionResult> CreateDepartment(DepartmentCreateDto departmentDto)
		{
			var response = await _serviceManager.DepartmentService.CreateDepartment(departmentDto);

			if (response.IsSuccess)
				return Ok(response);


			return BadRequest(response);
		}

		[HttpPut("{departmentId}")]
		public async Task<IActionResult> UpdateDepartment(DepartmentUpdateDto departmentDto, int departmentId)
		{
			if (!departmentId.Equals(departmentDto.departmentID))
				return BadRequest("Invalid ID");
			var response = await _serviceManager.DepartmentService.UpdateDepartment(departmentId, departmentDto);
			if (response.IsSuccess)
				return Ok(response);

			return BadRequest(response);
		}

		[HttpDelete("{departmentId}")]
		public async Task<IActionResult> DeleteDepartment(int departmentId)
		{
			var response = await _serviceManager.DepartmentService.DeleteDepartment(departmentId);

			if (response)
				return Ok("Department Deleted");

			return BadRequest("Failed to Delete Department.");
		}
	}
}

