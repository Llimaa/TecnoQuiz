using FluentValidation;
using TecnoQuiz.Application.Commands.Answers.Inputs;

namespace TecnoQuiz.Application.Validators.Commands.Answers
{
    public class UpdateAnswerCommandValidator: AbstractValidator<UpdateAnswerCommand>
    {
        public UpdateAnswerCommandValidator()
        {
            RuleFor(x => x.Id)
               .NotNull()
               .NotEmpty()
               .WithMessage("O campo ) não pode ser vazio ou nulo");

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
