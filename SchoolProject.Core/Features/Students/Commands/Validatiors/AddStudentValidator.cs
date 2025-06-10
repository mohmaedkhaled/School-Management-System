using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Students.Commands.Results
{
    public class AddStudentValidator : AbstractValidator<AddStudentCommand>
    {
        #region Fields

        private readonly IStudentService _studentService;
        private readonly IStringLocalizer<SharedResources> _localizer;
        #endregion


        #region Constructor
        public AddStudentValidator(IStudentService studentService,
                                    IStringLocalizer<SharedResources> localizer)
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
                .MaximumLength(100).WithMessage(_localizer[SharedResourcesKey.MaxLengthis100]);


        }

        public void ApplyCustomValidationsRules()
        {
            RuleFor(x => x.NameAr)
                .MustAsync(async (key, CancellationToken) => !await _studentService.IsNameArExist(key))
                .WithMessage(_localizer[SharedResourcesKey.IsExist]);
            RuleFor(x => x.NameEn)
                .MustAsync(async (key, CancellationToken) => !await _studentService.IsNameEnExist(key))
                .WithMessage(_localizer[SharedResourcesKey.IsExist]);
        }

        #endregion
    }
}
