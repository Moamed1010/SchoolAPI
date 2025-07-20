using AutoMapper;

using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using School.Core.Basecs;
using School.Core.Features.ApplicationUser.Commands.Models;
using School.Core.Resources;
using School.Data.Models.Identity;

namespace School.Core.Features.ApplicationUser.Commands.Handlers
{

    public class UserCommandHandler : ResponseHandler,
    IRequestHandler<AddUserCommand, Response<string>>
    {
        #region Fildes
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _sharedResources;
        private readonly UserManager<User> _userManager;
        #endregion


        #region Ctor
        public UserCommandHandler(IStringLocalizer<SharedResources> sharedResources,
                                  IMapper mapper,
                                  UserManager<User> userManager) : base(sharedResources)
        {
            _mapper = mapper;
            _sharedResources = sharedResources;
            _userManager = userManager;
        }





        #endregion



        #region Handel Functions
        public async Task<Response<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user != null) return BadRequest<string>(_sharedResources[SharedResourcesKeys.EmailIsExist]);
            var userbyuserName = await _userManager.FindByNameAsync(request.UserName);
            if (userbyuserName != null) return BadRequest<string>(_sharedResources[SharedResourcesKeys.UserNameIsExist]);

            var identiyUser = _mapper.Map<User>(request);
            var createResult = await _userManager.CreateAsync(identiyUser, request.Password);

            if (!createResult.Succeeded)
            {
                return BadRequest<string>(_sharedResources[SharedResourcesKeys.FaildToAddUser]);
            }

            return Created("");
        }
        #endregion

    }
}
