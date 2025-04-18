using FluentValidation;
using FitnessTrackerApi.DTOs.WorkoutType;

namespace FitnessTrackerApi.Validators;

public class WorkoutTypeUpdateDtoValidator : AbstractValidator<WorkoutTypeUpdateDto>
{
    public WorkoutTypeUpdateDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Название обязательно!")
            .MaximumLength(100).WithMessage("Максимальная длина 100 символов!");
    }
}