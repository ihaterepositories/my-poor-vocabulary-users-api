using Data.Dtos.StudentDtos;
using FluentValidation;

namespace BLL.Validators;

public class UpdateStudentProgressDtoValidator : AbstractValidator<UpdateStudentProgressDto>
{
    public UpdateStudentProgressDtoValidator()
    {
        RuleFor(x => x.StudentId)
            .NotEmpty().WithMessage("StudentId is required.")
            .Must(id => Guid.TryParse(id.ToString(), out _))
            .WithMessage("StudentId must be a valid GUID.");

        RuleFor(x => x.LastVisitation)
            .NotEmpty().WithMessage("LastVisitation is required.")
            .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("LastVisitation cannot be in the future.");

        RuleFor(x => x.GamesCompleted)
            .NotEmpty().WithMessage("GamesCompleted is required.")
            .GreaterThanOrEqualTo(0).WithMessage("GamesCompleted must be 0 or greater.");

        RuleFor(x => x.AverageScorePerGame)
            .NotEmpty().WithMessage("AverageScorePerGame is required.")
            .GreaterThanOrEqualTo(0).WithMessage("AverageScorePerGame must be 0 or greater.");

        RuleFor(x => x.WordsCountInVocabulary)
            .NotEmpty().WithMessage("WordsCountInVocabulary is required.")
            .GreaterThanOrEqualTo(0).WithMessage("WordsCountInVocabulary must be 0 or greater.");

        RuleFor(x => x.LastVocabularyUpdate)
            .NotEmpty().WithMessage("LastVocabularyUpdate is required.")
            .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("LastVocabularyUpdate cannot be in the future.");
    }
}