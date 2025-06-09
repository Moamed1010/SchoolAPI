using AutoMapper;

namespace School.Core.Mapping.Departments
{
    public partial class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            GetDepartmentByIDMapping();
            AddStudentCommandMapping();
            DepartmentListMapping();
            EditDepartmentCommandMapping();
        }
    }
}
