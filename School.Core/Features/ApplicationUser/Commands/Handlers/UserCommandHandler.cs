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
    IRequestHandler<AddUserCommand, Response<string>>,
    IRequestHandler<EditUserCommand, Response<string>>,
    IRequestHandler<DeleteUserCommand, Response<string>>
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

        public async Task<Response<string>> Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
            var oldUser = await _userManager.FindByIdAsync(request.Id.ToString());
            if (oldUser == null) return NotFound<string>(_sharedResources[SharedResourcesKeys.NotFound]);
            var newUser = _mapper.Map(request, oldUser);
            var result = await _userManager.UpdateAsync(newUser);
            if (!result.Succeeded)
            {
                return BadRequest<string>(_sharedResources[SharedResourcesKeys.UpdatedFailed]);
            }
            return Success((string)_sharedResources[SharedResourcesKeys.Updated]);

        }

        public async Task<Response<string>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId.ToString());
            if (user == null) return NotFound<string>(_sharedResources[SharedResourcesKeys.NotFound]);
            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                return BadRequest<string>(_sharedResources[SharedResourcesKeys.DeletedFailed]);
            }

            return Success<string>(_sharedResources[SharedResourcesKeys.Deleted]);
        }

        #endregion

    }
}
