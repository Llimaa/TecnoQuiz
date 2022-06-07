using FluentValidation;
using TecnoQuiz.Application.Commands.Quizzes.Inputs;

namespace TecnoQuiz.Application.Validators.Commands.Quizzes
{
    public class RemoveQuizCommandValidator : AbstractValidator<RemoveQuizCommand>
    {
        public RemoveQuizCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty()
                .NotNull()
                .WithMessage("O campo Id não pode ser vazio ou nulo");
        }
    }
}
