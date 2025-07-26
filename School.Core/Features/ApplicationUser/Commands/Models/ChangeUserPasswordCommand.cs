
using MediatR;
using School.Core.Basecs;

namespace School.Core.Features.ApplicationUser.Commands.Models
{
    public class ChangeUserPasswordCommand : IRequest<Response<string>>
    {
        public int id { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }

    }
}
