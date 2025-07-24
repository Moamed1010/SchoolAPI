using School.Core.Features.ApplicationUser.Queries.Result;
using School.Data.Models.Identity;

namespace School.Core.Mapping.ApplicationUser
{
    public partial class ApplicationUserProfile
    {
        public void GetUserByIdMapping()
        {
            CreateMap<User, GetUserByIdResponse>();

        }
    }
}
