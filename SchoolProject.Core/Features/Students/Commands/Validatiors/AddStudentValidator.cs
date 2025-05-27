using FluentValidation;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Students.Commands.Results
{
    public class AddStudentValidator : AbstractValidator<AddStudentCommand>
    {
        #region Fields

        private readonly IStudentService _studentService;
        #endregion


        #region Constructor
        public AddStudentValidator(IStudentService studentService)
        {
            _studentService = studentService;
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }
        #endregion


        #region Action
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name Must not Be Empty")
                .NotNull().WithMessage("Name Must not Be NULL")
                .MaximumLength(10).WithMessage("Max Length 10");


            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("{PropertyName} Must not Be Empty")
                .NotNull().WithMessage("{PropertyValue} Must not Be NULL")
                .MaximumLength(10).WithMessage("{PropertyName} Length 10");


        }

        public void ApplyCustomValidationsRules()
        {
            RuleFor(x => x.Name)
                .MustAsync(async (key, CancellationToken) => !await _studentService.IsNameExist(key))
                .WithMessage("Name Is Exist");
        }

        #endregion
    }
}
