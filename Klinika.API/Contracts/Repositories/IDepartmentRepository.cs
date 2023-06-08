using Klinika.API.Models;

namespace Klinika.API.Contracts.Repositories
{
    public interface IDepartmentRepository : IBaseRepository<Department>
    {
        Task<IEnumerable<Department>> GetAllDepartments();
        Task<Department> GetDepartmentById(int diagnoseId);
        void CreateDepartment(Department department);
        void UpdateDepartment(Department department);
        void DeleteDepartment(Department department);
    }
}
