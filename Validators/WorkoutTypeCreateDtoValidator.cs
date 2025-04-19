using FluentValidation;
using FitnessTrackerApi.DTOs.WorkoutType;

namespace FitnessTrackerApi.Validators;

public class WorkoutTypeCreateDtoValidator : AbstractValidator<WorkoutTypeCreateDto>
{
    public WorkoutTypeCreateDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Пожалуйста, укажите название типа тренировки.")
            .MaximumLength(100).WithMessage("Название не должно превышать 100 символов.")
            .Must(name => !string.IsNullOrWhiteSpace(name))
            .WithMessage("Название не может состоять только из пробелов.")
            .Matches("^[a-zA-Zа-яА-Я0-9 \\-]+$")
            .WithMessage("Название может содержать только буквы, цифры, пробелы и дефис.");
    }
}