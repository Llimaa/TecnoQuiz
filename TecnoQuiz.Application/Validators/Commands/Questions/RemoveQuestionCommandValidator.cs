using FluentValidation;
using TecnoQuiz.Application.Commands.Questions.Inputs;

namespace TecnoQuiz.Application.Validators.Commands.Questions
{
    public class RemoveQuestionCommandValidator : AbstractValidator<RemoveQuestionCommand>
    {
        public RemoveQuestionCommandValidator()
        {
            RuleFor(x => x.Id)
               .NotNull()
               .NotEmpty()
               .WithMessage("O campo Id não pode ser vazio ou nulo");
        }
    }
}
