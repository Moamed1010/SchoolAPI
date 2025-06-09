using FluentValidation;
using Microsoft.Extensions.Localization;
using School.Core.Features.Department.Commands.Models;
using School.Core.Resources;
using School.service.Abstracts;

namespace School.Core.Features.Department.Commands.Validators
{
    public class AddDepartmentValidator : AbstractValidator<AddDepartmentCommand>

    {
        #region Fields
        private readonly IStudentService _studentService;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;

        #endregion

        #region Constructors
        public AddDepartmentValidator(IStudentService studentService,
                                                        IStringLocalizer<SharedResources> stringLocalizer)
        {
            _studentService = studentService;
            _stringLocalizer = stringLocalizer;
            ApplyValidationsRoles();
            ApplyCustomValidations();
        }
        #endregion
        #region Actions
        public void ApplyValidationsRoles()
        {
            RuleFor(x => x.DNameAr)
                .NotEmpty()
                .WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .NotNull()
                .WithMessage(_stringLocalizer[SharedResourcesKeys.Required])
                .MaximumLength(100)
                .WithMessage(_stringLocalizer[SharedResourcesKeys.MaxLength]);

            RuleFor(x => x.DNameEn)
                .NotEmpty()
                .WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .NotNull()
                .WithMessage(_stringLocalizer[SharedResourcesKeys.Required])
                .MaximumLength(100)
                .WithMessage(_stringLocalizer[SharedResourcesKeys.MaxLength]);



        }
        public void ApplyCustomValidations()
        {
            RuleFor(x => x.DNameAr)
                 .MustAsync(async (Key, CancellationToken) => !await _studentService.IsNameExist(Key))
                 .WithMessage(_stringLocalizer[SharedResourcesKeys.IsExist]);
            RuleFor(x => x.DNameEn)
                 .MustAsync(async (Key, CancellationToken) => !await _studentService.IsNameExist(Key))
                 .WithMessage(_stringLocalizer[SharedResourcesKeys.IsExist]);
        }
        #endregion
    }
}
