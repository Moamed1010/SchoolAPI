using School.Core.Wrappers;

namespace School.Core.Features.Department.Quaries.Results
{
    public class GetDepartmentByIDQueryResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ManagerName { get; set; }

        public PaginatedResult<StudentResponse>? StudentList { get; set; }
        public List<SubjectResponse>? SubjectList { get; set; }
        public List<InstructorsResponse>? InstructorsList { get; set; }


    }
    public class StudentResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public StudentResponse(int id, string name)
        {
            Id = id;
            Name = name;

        }

    }


    public class SubjectResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class InstructorsResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
