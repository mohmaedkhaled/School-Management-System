using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Students.Commands.Validatiors
{
    public class EditStudentValidator : AbstractValidator<EditStudentCommand>
    {
        #region Fields

        private readonly IStudentService _studentService;
        private readonly IStringLocalizer<SharedResources> _localizer;
        #endregion


        #region Constructor
        public EditStudentValidator(IStudentService studentService, IStringLocalizer<SharedResources> localizer)
        {
            _studentService = studentService;
            _localizer = localizer;
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }
        #endregion


        #region Action
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.NameAr)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKey.NotEmpty])
                .NotNull().WithMessage(_localizer[SharedResourcesKey.Required])
                .MaximumLength(100).WithMessage(_localizer[SharedResourcesKey.MaxLengthis100]);


            RuleFor(x => x.Address)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKey.NotEmpty])
                .NotNull().WithMessage(_localizer[SharedResourcesKey.Required])
                .MaximumLength(10).WithMessage(_localizer[SharedResourcesKey.MaxLengthis100]);


        }

        public void ApplyCustomValidationsRules()
        {
            RuleFor(x => x.NameAr)
                .MustAsync(async (model, key, CancellationToken) => !await _studentService.IsNameArExistExcludeSelf(key, model.Id))
                .WithMessage(_localizer[SharedResourcesKey.IsExist]);
            RuleFor(x => x.NameEn)
                .MustAsync(async (model, key, CancellationToken) => !await _studentService.IsNameEnExistExcludeSelf(key, model.Id))
                .WithMessage(_localizer[SharedResourcesKey.IsExist]);
        }
        #endregion

    }
}
