using FluentValidation;
using TecnoQuiz.Application.Commands.Answers.Inputs;

namespace TecnoQuiz.Application.Validators.Commands.Answers
{
    public class CreateAnswerCommandValidator : AbstractValidator<CreateAnswerCommand>
    {
        public CreateAnswerCommandValidator()
        {
            RuleFor(x => x.QuestionId)
                .NotNull()
                .NotEmpty()
                .WithMessage("O campo QuestionId não pode ser vazio ou nulo");

            RuleFor(x => x.Description)
                .Length(5, 300)
                .WithMessage("O campo Answer deve ter entre 5 e 300 caracteres");

            RuleFor(x => x.IsRight)
                .NotEmpty()
                .NotNull()
                .WithMessage("O campo IsRight não pode ser vazio ou nulo");
        }
    }
}
