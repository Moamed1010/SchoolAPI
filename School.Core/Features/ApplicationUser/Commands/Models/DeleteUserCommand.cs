using MediatR;
using School.Core.Basecs;

namespace School.Core.Features.ApplicationUser.Commands.Models
{
    public class DeleteUserCommand : IRequest<Response<string>>
    {
        public int UserId { get; set; }
        public DeleteUserCommand(int userId)
        {
            UserId = userId;
        }

    }
}
