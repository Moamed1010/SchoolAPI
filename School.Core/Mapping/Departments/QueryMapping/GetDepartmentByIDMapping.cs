using School.Core.Features.Department.Quaries.Results;
using School.Core.Wrappers;
using School.Data.Models;

namespace School.Core.Mapping.Departments
{
    public partial class DepartmentProfile
    {
        public void GetDepartmentByIDMapping()
        {
            //CreateMap<Department, GetDepartmentByIDQueryResponse>()
            //   .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Localize(src.DNameAr, src.DNameEn)))
            //   .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.DID))
            //   .ForMember(dest => dest.ManagerName
            //   , opt => opt.MapFrom(src => src.Instructor
            //   .Localize(src.Instructor.ENameAr, src.Instructor.ENameEn)))
            //    .ForMember(dest => dest.SubjectList, opt => opt.MapFrom(src => src.DepartmentSubjects))
            //    .ForMember(dest => dest.InstructorsList, opt => opt.MapFrom(src => src.Instructors))
            //    .ForMember(dest => dest.StudentList, opt => opt.MapFrom(src => src.Students));
            CreateMap<Department, GetDepartmentByIDQueryResponse>()
    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Localize(src.DNameAr, src.DNameEn)))
    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.DID))
    .ForMember(dest => dest.ManagerName, opt => opt.MapFrom(src => src.Instructor.Localize(src.Instructor.ENameAr, src.Instructor.ENameEn)))
    .ForMember(dest => dest.SubjectList, opt => opt.MapFrom(src => src.DepartmentSubjects))
    .ForMember(dest => dest.InstructorsList, opt => opt.MapFrom(src => src.Instructors))
    .ForMember(dest => dest.StudentList, opt => opt.MapFrom(src =>
        PaginatedResult<StudentResponse>.Success(
            src.Students.Select(s => new StudentResponse(
                s.StudID,
                s.Localize(s.NameAr, s.NameEn)))
            .ToList(),
            src.Students.Count,
            1,
            10
        )
    ));

            CreateMap<DepartmetSubject, SubjectResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.SubID))
                .ForMember(dest => dest.Name
                , opt => opt.MapFrom(src => src.Subjects
                .Localize(src.Subjects.SubjectNameAr, src.Subjects.SubjectNameEn)));

            CreateMap<Student, StudentResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.StudID))
                .ForMember(dest => dest.Name
                , opt => opt.MapFrom(src => src.Localize(src.NameAr, src.NameEn)));

            CreateMap<Instructor, InstructorsResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.InsId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Localize(src.ENameAr, src.ENameEn)));

        }
    }
}
