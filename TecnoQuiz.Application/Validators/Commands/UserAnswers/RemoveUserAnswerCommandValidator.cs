using FluentValidation;
using TecnoQuiz.Application.Commands.UserAnswers.Inputs;

namespace TecnoQuiz.Application.Validators.Commands.UserAnswers
{
    public class RemoveUserAnswerCommandValidator : AbstractValidator<RemoveUserAnswerCommand>
    {
        public RemoveUserAnswerCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty()
                .NotNull()
                .WithMessage("O campo Id não pode ser vazio ou nulo");
        }
    }
}
