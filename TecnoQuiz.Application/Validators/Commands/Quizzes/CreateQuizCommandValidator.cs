using FluentValidation;
using TecnoQuiz.Application.Commands.Quizzes.Inputs;

namespace TecnoQuiz.Application.Validators.Commands.Quizzes
{
    public class CreateQuizCommandValidator : AbstractValidator<CreateQuizCommand>
    {
        public CreateQuizCommandValidator()
        {
            RuleFor(x => x.Title)
                .Length(5, 50)
                .WithMessage("O campo Title deve conter de 5 a 50 Caracteres");


            RuleFor(x => x.Description)
                .Length(10, 300)
                .WithMessage("O campo Title deve conter de 10 a 300 Caracteres");

            RuleFor(x => x.UserId)
                .NotNull()
                .NotEmpty()
                .WithMessage("O campo UserId não pode ser vazio ou nulo");
        }
    }
}
