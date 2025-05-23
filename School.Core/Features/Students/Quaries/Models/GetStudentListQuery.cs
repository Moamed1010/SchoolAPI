using MediatR;
using School.Core.Basecs;
using School.Core.Features.Students.Quaries.Results;
using School.Data.Models;

namespace School.Core.Features.Students.Quaries.Models
{
    public class GetStudentListQuery : IRequest<Response<List<GetStudentListResponse>>>
    {
    }
}
