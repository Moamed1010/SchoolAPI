using School.Core.Features.ApplicationUser.Commands.Models;
using School.Data.Models.Identity;

namespace School.Core.Mapping.ApplicationUser
{
    public partial class ApplicationUserProfile
    {
        public void UpdateUserMapping()
        {
            CreateMap<EditUserCommand, User>();

        }
    }
}
