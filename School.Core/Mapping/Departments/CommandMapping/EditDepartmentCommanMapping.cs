using School.Core.Features.Department.Commands.Models;

namespace School.Core.Mapping.Departments
{
    public partial class DepartmentProfile
    {
        public void EditDepartmentCommandMapping()
        {
            CreateMap<EditDepartmentCommand, Data.Models.Department>()
                .ForMember(dest => dest.DID, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.DNameAr, opt => opt.MapFrom(src => src.DNameAr))
                .ForMember(dest => dest.DNameEn, opt => opt.MapFrom(src => src.DNameEn))
                .ForMember(dest => dest.InsManager, opt => opt.MapFrom(src => src.ManagerId));
        }
    }
}
