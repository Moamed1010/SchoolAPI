using FluentValidation;
using Microsoft.Extensions.Localization;
using School.Core.Features.Students.Commands.Models;
using School.Core.Resources;
using School.service.Abstracts;

namespace School.Core.Features.Students.Commands.Validators
{
    public class EtidStudentValidator : AbstractValidator<EditStudentCommand>
    {

        private readonly IStudentService _studentService;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;



        #region Constructors
        public EtidStudentValidator(IStudentService studentService,
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
            RuleFor(x => x.NameAr)
                .NotEmpty()
                .WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .NotNull()
                .WithMessage(_stringLocalizer[SharedResourcesKeys.Required])
                .MaximumLength(100)
                .WithMessage(_stringLocalizer[SharedResourcesKeys.MaxLength])
                .MinimumLength(3)
                .WithMessage("MinimumLength is 3");
            RuleFor(x => x.NameEn)
                .NotEmpty()
                .WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .NotNull()
                .WithMessage(_stringLocalizer[SharedResourcesKeys.Required])
                .MaximumLength(100)
                .WithMessage(_stringLocalizer[SharedResourcesKeys.MaxLength])
                .MinimumLength(3)
                .WithMessage("MinimumLength is 3");
            RuleFor(x => x.Address)
                .NotEmpty()
                .WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .NotNull()
                .WithMessage(_stringLocalizer[SharedResourcesKeys.Required]);


        }
        public void ApplyCustomValidations()
        {
            RuleFor(x => x.NameAr)
     .MustAsync(async (model, name, cancellationToken) =>
         !await _studentService.IsNameExistExcludeSelf(name, model.Id))
     .WithMessage(_stringLocalizer[SharedResourcesKeys.IsExist]);
            RuleFor(x => x.NameEn)
    .MustAsync(async (model, name, cancellationToken) =>
        !await _studentService.IsNameExistExcludeSelf(name, model.Id))
    .WithMessage(_stringLocalizer[SharedResourcesKeys.IsExist]);
        }
        #endregion
    }
}


