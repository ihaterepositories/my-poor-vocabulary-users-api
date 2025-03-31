using Data.Dtos.SchoolDtos;
using FluentValidation;

namespace BLL.Validators;

public class CreateSchoolDtoValidator : AbstractValidator<CreateSchoolDto>
{
    public CreateSchoolDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("School name is required.")
            .MaximumLength(200).WithMessage("School name cannot exceed 200 characters.");
        
        RuleFor(x => x.Address)
            .NotEmpty().WithMessage("Address is required.")
            .MaximumLength(200).WithMessage("Address cannot exceed 200 characters.");
        
        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("Phone number is required.")
            .MaximumLength(20).WithMessage("Phone number cannot exceed 20 characters.");
        
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email address.");
        
        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.")
            .MinimumLength(6).WithMessage("Password must be at least 6 characters.")
            .MaximumLength(50).WithMessage("Password cannot exceed 50 characters.");

        RuleFor(x => x.KeyForEnrollment)
            .NotEmpty().WithMessage("Key for enrollment is required.");
    }
}