using FluentValidation;
using TecnoQuiz.Application.Commands.Users.Inputs;

namespace TecnoQuiz.Application.Validators.Commands.Users
{
    public class ActiveUserCommandValidator : AbstractValidator<ActiveUserCommand>
    {
        public ActiveUserCommandValidator()
        {
            RuleFor(a => a.Id).NotEmpty()
                .NotNull()
                .WithMessage("O Id não pode ser null ou vazio");
        }
    }
}
