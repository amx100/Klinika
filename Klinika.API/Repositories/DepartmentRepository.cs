using Klinika.API.Contracts.Repositories;
using Klinika.API.Data;
using Klinika.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Klinika.API.Repositories
{
    public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(ApplicationDbContext context) : base(context) { }

        public void CreateDepartment(Department department) => Create(department);
        public void UpdateDepartment(Department department) => Update(department);
        public void DeleteDepartment(Department department) => Delete(department);
        public async Task<IEnumerable<Department>> GetAllDepartments() => await SelectAll().ToListAsync();
        public async Task<Department> GetDepartmentById(int departmentId) => await SelectByCondition(department => department.DepartmentID == departmentId).FirstOrDefaultAsync();

       
    }
}
