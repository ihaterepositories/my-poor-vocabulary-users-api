using Data.Dtos.StudentDtos;
using FluentValidation;

namespace BLL.Validators;

public class CreateStudentDtoValidator : AbstractValidator<CreateStudentDto>
{
    public CreateStudentDtoValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("First name cannot be empty")
            .MaximumLength(50).WithMessage("First name cannot be more than 50 characters");
        
        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("First name cannot be empty")
            .MaximumLength(50).WithMessage("First name cannot be more than 50 characters");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email address.")
            .MaximumLength(70).WithMessage("Email cannot be more than 70 characters");

        RuleFor(x => x.DateOfBirthUnformatted)
            .NotEmpty().WithMessage("Date of birth is required.")
            .Must(dateStr =>
                DateTime.TryParse(dateStr, out _))
            .WithMessage("Date of birth must be a valid date.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.")
            .MinimumLength(6).WithMessage("Password must be at least 6 characters long.")
            .MaximumLength(50).WithMessage("Password cannot exceed 50 characters.");

        RuleFor(x => x.SchoolKeyForEnrollment)
            .NotEmpty().WithMessage("School key for enrollment is required.");
        
        RuleFor(x => x.TeacherKeyForEnrollment)
            .NotEmpty().WithMessage("Teacher key for enrollment is required.");
    }
}