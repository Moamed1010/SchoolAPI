using MediatR;
using School.Core.Features.Students.Quaries.Results;
using School.Core.Wrappers;
using School.Data.Helper;

namespace School.Core.Features.Students.Quaries.Models
{
    public class GetStudentPaginatedListQuery : IRequest<PaginatedResult<GetStudentPaginatedListResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? Search { get; set; }

        public StudentOrderingEnum OrderBy { get; set; }


    }
}
