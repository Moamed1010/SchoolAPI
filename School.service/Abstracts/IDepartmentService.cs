using School.Data.Models;

namespace School.service.Abstracts
{
    public interface IDepartmentService
    {
        public Task<Department> GetDepartmentById(int id);
        public Task<List<Department>> GetListAsync();
        public Task<bool> AddAsync(Department department);
        public Task<bool> UpdateAsync(Department department);
        public Task<bool> DeleteAsync(Department department);
        Task<bool> IsNameExistExcludeSelf(string name, int id);
        public Task<bool> IsDepartmentIdExist(int departmentid);

    }
}
