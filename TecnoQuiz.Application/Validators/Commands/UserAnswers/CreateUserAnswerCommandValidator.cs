using FluentValidation;
using TecnoQuiz.Application.Commands.UserAnswers.Inputs;

namespace TecnoQuiz.Application.Validators.Commands.UserAnswers
{
    public class CreateUserAnswerCommandValidator : AbstractValidator<CreateUserAnswerCommand>
    {
        public CreateUserAnswerCommandValidator()
        {
            RuleFor(x => x.AnswerId).NotEmpty()
                .NotNull()
                .WithMessage("O campo AnswerId não pode ser valizo ou nulo");
        }
    }
}
