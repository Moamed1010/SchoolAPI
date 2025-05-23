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
        #endregion

        #region Handel Finction
        public async Task<Department> GetDepartmentById(int id)
        {
            var department = await _departmentRepository.GetTableNoTracking()
                   .Where(x => x.DID == id)
                   .Include(x => x.DepartmentSubjects)
                   .ThenInclude(x => x.Subjects)
                   //.Include(x => x.Students)
                   .Include(x => x.Instructors)
                   .Include(x => x.Instructor).FirstOrDefaultAsync();

            return department;
        }
        #endregion

    }
}
