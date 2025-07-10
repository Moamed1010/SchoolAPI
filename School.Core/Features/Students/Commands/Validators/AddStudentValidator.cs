using FluentValidation;
using Microsoft.Extensions.Localization;
using School.Core.Features.Students.Commands.Models;
using School.Core.Resources;
using School.service.Abstracts;

namespace School.Core.Features.Students.Commands.Validators
{
    public class AddStudentValidator : AbstractValidator<AddStudentCommand>
    {
        #region Fields
        private readonly IStudentService _studentService;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IDepartmentService _departmentService;

        #endregion

        #region Constructors
        public AddStudentValidator(IStudentService studentService,
                                                       IStringLocalizer<SharedResources> stringLocalizer
                                                        , IDepartmentService departmentService)
        {
            _departmentService = departmentService;
            _studentService = studentService;
            _stringLocalizer = stringLocalizer;
            ApplyValidationsRoles();
            ApplyCustomValidations();


        }

        #endregion

        #region Actions
        public void ApplyValidationsRoles()
        {
            RuleFor(x => x.NameAr)
                .NotEmpty()
                .WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .NotNull()
                .WithMessage(_stringLocalizer[SharedResourcesKeys.Required])
                .MaximumLength(100)
                .WithMessage(_stringLocalizer[SharedResourcesKeys.MaxLength]);

            RuleFor(x => x.NameEn)
                .NotEmpty()
                .WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .NotNull()
                .WithMessage(_stringLocalizer[SharedResourcesKeys.Required])
                .MaximumLength(100)
                .WithMessage(_stringLocalizer[SharedResourcesKeys.MaxLength]);
            RuleFor(x => x.Address)
                .NotEmpty()
                .WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .NotNull()
                .WithMessage(_stringLocalizer[SharedResourcesKeys.Required]);
            RuleFor(x => x.DepartmentId)
                .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.Required]);

        }
        public void ApplyCustomValidations()
        {
            RuleFor(x => x.NameAr)
                 .MustAsync(async (Key, CancellationToken) => !await _studentService.IsNameExist(Key))
                 .WithMessage(_stringLocalizer[SharedResourcesKeys.IsExist]);
            RuleFor(x => x.NameEn)
                 .MustAsync(async (Key, CancellationToken) => !await _studentService.IsNameExist(Key))
                 .WithMessage(_stringLocalizer[SharedResourcesKeys.IsExist]);
            RuleFor(x => x.DepartmentId)
                .MustAsync(async (Key, CancellationToken) => await _departmentService.IsDepartmentIdExist(Key))
                .WithMessage(_stringLocalizer[SharedResourcesKeys.IsNotExist]);
        }
        #endregion
    }
}
