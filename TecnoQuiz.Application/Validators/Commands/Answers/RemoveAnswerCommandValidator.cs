using FluentValidation;
using TecnoQuiz.Application.Commands.Answers.Inputs;

namespace TecnoQuiz.Application.Validators.Commands.Answers
{
    public class RemoveAnswerCommandValidator : AbstractValidator<RemoveAnswerCommand>
    {
        public RemoveAnswerCommandValidator()
        {
            RuleFor(x => x.Id)
              .NotNull()
              .NotEmpty()
              .WithMessage("O campo QuizId não pode ser vazio ou nulo");
        }
    }
}
