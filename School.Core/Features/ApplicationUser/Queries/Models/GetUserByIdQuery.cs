using MediatR;
using School.Core.Basecs;
using School.Core.Features.ApplicationUser.Queries.Result;

namespace School.Core.Features.ApplicationUser.Queries.Models
{
    public class GetUserByIdQuery : IRequest<Response<GetUserByIdResponse>>
    {
        public int Id { get; set; }

        public GetUserByIdQuery(int id)
        {
            Id = id;
        }
    }
}
