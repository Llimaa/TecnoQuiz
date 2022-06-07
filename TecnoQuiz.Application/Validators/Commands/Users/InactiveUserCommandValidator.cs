using FluentValidation;
using TecnoQuiz.Application.Commands.Users.Inputs;

namespace TecnoQuiz.Application.Validators.Commands.Users
{
    public class InactiveUserCommandValidator : AbstractValidator<InactiveUserCommand>
    {
        public InactiveUserCommandValidator()
        {
            RuleFor(i => i.Id)
                .NotEmpty()
                .WithMessage("O Id não pode ser null ou vazio");
        }
    }
}
