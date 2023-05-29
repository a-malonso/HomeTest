using FluentValidation;

namespace SaviaHomeTest.Application.UseCases.TaskToDo.Commands.CreateTaskToDo;

public class CreateTaskToDoCommandValidator : AbstractValidator<CreateTaskToDoCommand>
{
    public CreateTaskToDoCommandValidator()
    {
        RuleFor(x => x.Description)
            .NotNull().WithMessage("Description cannot be null")
            .NotEmpty().WithMessage("Description cannot be empty")
            .MaximumLength(200).WithMessage("Description cannot be longer than 200 characters");

        RuleFor(x => x.Priority)
            .IsInEnum().WithMessage("Priority value is not valid");

        //RuleFor<bool>(x => x.IsDone)
        //    .NotEmpty()
        //    .NotNull()
        //    .WithMessage("IsDone must have a value");
    }
}
