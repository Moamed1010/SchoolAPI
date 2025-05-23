using Microsoft.EntityFrameworkCore;
using School.Data.Helper;
using School.Data.Models;
using School.service.Abstracts;
using Shcool.Infrustructure.IRepositories;

namespace School.service.Implementations
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepositories _studentRepositories;

        public StudentService(IStudentRepositories studentRepositories)
        {
            _studentRepositories = studentRepositories;
        }

        //public async Task<string> AddAsync(Student student)
        //{

        //    //if(student.StudID != null)
        //    //    student.StudID=null;
        //    await _studentRepositories.AddAsync(student);
        //    return "Success";
        //}
        public async Task<bool> AddAsync(Student student)
        {
            try
            {
                await _studentRepositories.AddAsync(student);
                return true;
            }
            catch
            {
                // ممكن تضيف لوج هنا لاحقًا
                return false;
            }
        }

        public async Task<string> DeleteAsync(Student student)
        {
            var trans = _studentRepositories.BeginTransaction();
            try
            {
                await _studentRepositories.DeleteAsync(student);
                await trans.CommitAsync();
                return "Success";

            }
            catch
            {
                await trans.RollbackAsync();
                return "Failed";
            }


        }

        //public async Task<bool> EditAsync(Student student)
        //{
        //    await _studentRepositories.UpdateAsync(student);
        //    return "Success";
        //}
        public async Task<bool> EditAsync(Student student)
        {
            try
            {
                await _studentRepositories.UpdateAsync(student);
                return true;
            }
            catch
            {
                // optional: log exception here
                return false;
            }
        }

        public IQueryable<Student> FilterStudentPaginatedQueryable(StudentOrderingEnum orderingEnum, string search)
        {
            var querable = _studentRepositories.GetTableNoTracking()
                .Include(x => x.Department)
                .AsQueryable();

            if (search != null)
            {
                querable = querable.Where(x =>
              x.NameAr.Contains(search) ||
              x.Address.Contains(search) ||
              x.Phone.Contains(search) ||
              x.Department.DNameAr.Contains(search)
              );
            }
            switch (orderingEnum)
            {
                case StudentOrderingEnum.StudID:
                    querable = querable.OrderBy(x => x.StudID);
                    break;
                case StudentOrderingEnum.Name:
                    querable = querable.OrderBy(x => x.NameAr);
                    break;
                case StudentOrderingEnum.Address:
                    querable = querable.OrderBy(x => x.Address);
                    break;
                case StudentOrderingEnum.DepartmentName:
                    querable = querable.OrderBy(x => x.Department.DNameAr);
                    break;

                default:
                    break;
            }
            return querable;
        }

        public Task<Student> GetByIdAsync(int id)
        {
            var student = _studentRepositories.GetByIdAsync(id);
            return student;
        }

        public IQueryable<Student> GetStudentByDepartmentIDQueryable(int DID)
        {
            return _studentRepositories.GetTableNoTracking()
                .Where(x => x.DID == DID)
                .AsQueryable();

        }

        public async Task<Student> GetStudentByIdIncludeAsync(int id)
        {
            //var student = await _studentRepositories.GetByIdAsync(id);
            var student = _studentRepositories.GetTableNoTracking()
                 .Include(x => x.Department)
                 .Where(x => x.StudID.Equals(id))
                    .FirstOrDefault();
            return student;
        }

        public IQueryable<Student> GetStudentQueryable()
        {
            return _studentRepositories.GetTableNoTracking()
                 .Include(x => x.Department)
                 .AsQueryable();
        }

        public async Task<List<Student>> GetStudentsListAsync()
        {
            return await _studentRepositories.GetStudentListAsync();
        }

        public async Task<bool> IsNameExist(string name)
        {
            var student = _studentRepositories.GetTableNoTracking()
               .Where(x => x.NameAr.Equals(name))
               .FirstOrDefault();
            if (student == null)
                return false;
            return true;
        }

        public async Task<bool> IsNameExistExcludeSelf(string name, int id)
        {
            var student = await _studentRepositories.GetTableNoTracking()
                .Where(x => x.NameEn.Equals(name) & !x.StudID.Equals(id))
                .FirstOrDefaultAsync();
            if (student == null)
                return false;
            return true;
        }


    }
}
