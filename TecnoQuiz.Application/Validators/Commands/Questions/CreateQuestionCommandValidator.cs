using FluentValidation;
using TecnoQuiz.Application.Commands.Questions.Inputs;

namespace TecnoQuiz.Application.Validators.Commands.Questions
{
    public class CreateQuestionCommandValidator : AbstractValidator<CreateQuestionCommand>
    {
        public CreateQuestionCommandValidator()
        {
            RuleFor(x => x.QuizId)
               .NotNull()
               .NotEmpty()
               .WithMessage("O campo QuizId não pode ser vazio ou nulo");

            RuleFor(x => x.Description)
               .Length(5, 300)
               .WithMessage("O campo Description deve conter de 5 a 300 caracteres");


        }
    }
}
