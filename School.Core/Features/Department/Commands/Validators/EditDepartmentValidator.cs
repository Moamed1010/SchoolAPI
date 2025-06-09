using FluentValidation;
using Microsoft.Extensions.Localization;
using School.Core.Features.Department.Commands.Models;
using School.Core.Resources;
using School.service.Abstracts;

namespace School.Core.Features.Department.Commands.Validators
{
    public class EditDepartmentValidator : AbstractValidator<EditDepartmentCommand>
    {
        #region Fields
        private readonly IDepartmentService _departmentService;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        #endregion

        #region Constructors
        public EditDepartmentValidator(IDepartmentService departmentService,
                                       IStringLocalizer<SharedResources> stringLocalizer)
        {
            _departmentService = departmentService;
            _stringLocalizer = stringLocalizer;

            ApplyValidationRules();
            ApplyCustomValidations();
        }
        #endregion

        #region Rules
        private void ApplyValidationRules()
        {
            RuleFor(x => x.DNameAr)
                .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .MaximumLength(100).WithMessage(_stringLocalizer[SharedResourcesKeys.MaxLength]);

            RuleFor(x => x.DNameEn)
                .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .MaximumLength(100).WithMessage(_stringLocalizer[SharedResourcesKeys.MaxLength]);
        }

        private void ApplyCustomValidations()
        {
            RuleFor(x => x.DNameAr)
                .MustAsync(async (model, nameAr, ct) =>
                    !await _departmentService.IsNameExistExcludeSelf(nameAr, model.Id))
                .WithMessage(_stringLocalizer[SharedResourcesKeys.IsExist]);

            RuleFor(x => x.DNameEn)
                .MustAsync(async (model, nameEn, ct) =>
                    !await _departmentService.IsNameExistExcludeSelf(nameEn, model.Id))
                .WithMessage(_stringLocalizer[SharedResourcesKeys.IsExist]);
        }
        #endregion
    }
}
