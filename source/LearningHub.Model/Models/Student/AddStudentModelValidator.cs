using DotNetCore.Validation;
using FluentValidation;

namespace LearningHub.Model.Models
{
    public sealed class AddStudentModelValidator : Validator<AddStudentModel>
    {
        public AddStudentModelValidator()
        {
            RuleFor(x => x).NotNull();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Age).NotEqual(0);
            RuleFor(x => x.CourseId).NotEqual(0);
        }
    }
}
