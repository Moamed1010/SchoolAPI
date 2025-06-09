using AutoMapper;
using School.Core.Features.Department.Commands.Models;
using School.Data.Models;
namespace School.Core.Mapping.Departments
{
    public partial class DepartmentProfile : Profile
    {
        public void AddStudentCommandMapping()
        {
            CreateMap<AddDepartmentCommand, Department>()
                .ForMember(dest => dest.DNameAr, opt => opt.MapFrom(src => src.DNameAr))
                .ForMember(dest => dest.DNameEn, opt => opt.MapFrom(src => src.DNameEn))
                .ForMember(dest => dest.InsManager, opt => opt.MapFrom(src => src.ManagerId))



            ;



        }
    }
}
