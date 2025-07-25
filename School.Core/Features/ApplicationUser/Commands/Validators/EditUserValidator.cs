using FluentValidation;
using Microsoft.Extensions.Localization;
using School.Core.Features.ApplicationUser.Commands.Models;
using School.Core.Resources;

namespace School.Core.Features.ApplicationUser.Commands.Validators
{
    public class EditUserValidator : AbstractValidator<EditUserCommand>
    {
        #region Fildes
        private readonly IStringLocalizer<SharedResources> _localization;

        #endregion

        #region Constractors

        public EditUserValidator(IStringLocalizer<SharedResources> localization)
        {

            _localization = localization;
            ApplyValidationsRoles();
            ApplyCustomValidations();
        }
        #endregion


        #region Handel Function

        public void ApplyValidationsRoles()
        {
            RuleFor(x => x.FullName)
                .NotEmpty()
                .WithMessage(_localization[SharedResourcesKeys.NotEmpty])
                .NotNull()
                .WithMessage(_localization[SharedResourcesKeys.Required])
                .MaximumLength(100)
                .WithMessage(_localization[SharedResourcesKeys.MaxLength]);

            RuleFor(x => x.UserName)
                .NotEmpty()
                .WithMessage(_localization[SharedResourcesKeys.NotEmpty])
                .NotNull()
                .WithMessage(_localization[SharedResourcesKeys.Required])
                .MaximumLength(100)
                .WithMessage(_localization[SharedResourcesKeys.MaxLength]);
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage(_localization[SharedResourcesKeys.NotEmpty])
                .NotNull()
                .WithMessage(_localization[SharedResourcesKeys.Required]);


        }
        public void ApplyCustomValidations()
        {

        }
        #endregion

    }
}
