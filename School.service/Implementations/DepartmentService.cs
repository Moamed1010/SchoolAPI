using Microsoft.EntityFrameworkCore;
using School.Data.Models;
using School.service.Abstracts;
using Shcool.Infrustructure.Abstract;

namespace School.service.Implementations
{
    public class DepartmentService : IDepartmentService
    {

        #region Fieds
        private readonly IDepartmentRepository _departmentRepository;
        #endregion
        #region Constructor
        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;

        }

        public async Task<bool> AddAsync(Department department)
        {
            try
            {
                await _departmentRepository.AddAsync(department);
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region Handel Finction
        public async Task<Department> GetDepartmentById(int id)
        {
            var department = await _departmentRepository.GetTableAsTracking()
                   .Where(x => x.DID == id)
                   .Include(x => x.DepartmentSubjects)
                   .ThenInclude(x => x.Subjects)

                   .Include(x => x.Instructors)
                   .Include(x => x.Instructor).FirstOrDefaultAsync();

            return department;
        }

        public async Task<List<Department>> GetListAsync()
        {
            return await _departmentRepository.GetTableNoTracking()
                .Include(x => x.Instructor)

                .Include(x => x.Instructors).ToListAsync();

        }
        public async Task<bool> UpdateAsync(Department department)
        {
            try
            {
                await _departmentRepository.UpdateAsync(department);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> DeleteAsync(Department department)
        {
            try
            {
                await _departmentRepository.DeleteAsync(department);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> IsNameExistExcludeSelf(string name, int id)
        {
            return await _departmentRepository.GetTableNoTracking()
                .AnyAsync(x => x.DNameEn == name && x.DID != id);
        }


        #endregion

    }
}
