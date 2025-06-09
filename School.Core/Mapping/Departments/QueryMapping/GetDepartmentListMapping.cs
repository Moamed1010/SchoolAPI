using School.Core.Features.Department.Quaries.Results;
using School.Data.Models;
namespace School.Core.Mapping.Departments
{

    public partial class DepartmentProfile
    {
        public void DepartmentListMapping()
        {
            CreateMap<Department, GetDepartmentListResponse>()
             .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.DID))
             .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Localize(src.DNameAr, src.DNameEn)))
             .ForMember(dest => dest.ManagerName, opt => opt.MapFrom(src => src.Instructor.Localize(src.Instructor.ENameAr, src.Instructor.ENameEn)));

        }

    }
}
