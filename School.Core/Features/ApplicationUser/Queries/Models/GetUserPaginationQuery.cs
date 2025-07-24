using MediatR;
using School.Core.Features.ApplicationUser.Queries.Result;
using School.Core.Wrappers;

namespace School.Core.Features.ApplicationUser.Queries.Models
{
    public class GetUserPaginationQuery : IRequest<PaginatedResult<GetUserPaginationResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
