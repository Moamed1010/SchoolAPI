using School.Data.Helper;
using School.Data.Models;

namespace School.service.Abstracts
{
    public interface IStudentService
    {
        public Task<List<Student>> GetStudentsListAsync();
        public Task<Student> GetStudentByIdIncludeAsync(int id);
        public Task<Student> GetByIdAsync(int id);

        public Task<bool> AddAsync(Student student);
        public Task<bool> EditAsync(Student student);
        public Task<string> DeleteAsync(Student student);
        public Task<bool> IsNameExist(string name);
        public Task<bool> IsNameExistExcludeSelf(string name, int id);
        public IQueryable<Student> GetStudentQueryable();
        public IQueryable<Student> GetStudentByDepartmentIDQueryable(int DID);
        public IQueryable<Student> FilterStudentPaginatedQueryable(StudentOrderingEnum orderingEnum, string search);

    }
}
