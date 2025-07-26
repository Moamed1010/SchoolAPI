using FluentValidation;
using Microsoft.Extensions.Localization;
using School.Core.Features.ApplicationUser.Commands.Models;
using School.Core.Resources;

namespace School.Core.Features.ApplicationUser.Commands.Validators
{
    public class ChangePasswordValidator : AbstractValidator<ChangeUserPasswordCommand>
    {
        #region Fildes
        private readonly IStringLocalizer<SharedResources> _localization;

        #endregion

        #region Constractors

        public ChangePasswordValidator(IStringLocalizer<SharedResources> localization)
        {

            _localization = localization;
            ApplyValidationsRoles();
            ApplyCustomValidations();
        }
        #endregion

        #region Handel Function
        public void ApplyValidationsRoles()
        {
            RuleFor(x => x.id)
                .NotEmpty().WithMessage(_localization[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_localization[SharedResourcesKeys.Required]);
            RuleFor(x => x.CurrentPassword)
                .NotEmpty().WithMessage(_localization[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_localization[SharedResourcesKeys.Required]);
            RuleFor(x => x.NewPassword)
                .NotEmpty().WithMessage(_localization[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_localization[SharedResourcesKeys.Required]);
            RuleFor(x => x.ConfirmPassword)
                .Equal(x => x.NewPassword).WithMessage(_localization[SharedResourcesKeys.PasswordNptEqualConfiemPassword]);

        }
        public void ApplyCustomValidations()
        {

        }
        #endregion
    }
}
