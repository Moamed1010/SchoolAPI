
using MediatR;
using School.Core.Basecs;
using School.Core.Features.Department.Quaries.Results;

namespace School.Core.Features.Department.Quaries.Models
{
    public class GetDepartmentListQuery : IRequest<Response<List<GetDepartmentListResponse>>>
    {
    }
}
