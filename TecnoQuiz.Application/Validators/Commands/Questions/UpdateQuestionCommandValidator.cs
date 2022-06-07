using FluentValidation;
using TecnoQuiz.Application.Commands.Questions.Inputs;

namespace TecnoQuiz.Application.Validators.Commands.Questions
{
    public class UpdateQuestionCommandValidator : AbstractValidator<UpdateQuestionCommand>
    {
        public UpdateQuestionCommandValidator()
        {
            RuleFor(x => x.Id)
             .NotNull()
             .NotEmpty()
             .WithMessage("O campo ) não pode ser vazio ou nulo");

            RuleFor(x => x.Description)
               .Length(5, 300)
               .WithMessage("O campo Description deve conter de 5 a 300 caracteres");
        }
    }
}
