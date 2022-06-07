using FluentValidation;
using TecnoQuiz.Application.Commands.Users.Inputs;

namespace TecnoQuiz.Application.Validators.Commands.Users
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("O Id não pode ser null ou vazio");

            RuleFor(c => c.FullName)
                .Length(10, 200)
                .WithMessage("O Campo Fullname deve ter entre 10 e 200 caracteres");

            RuleFor(c => c.Email)
                .NotEmpty()
                .WithMessage("O campo Email é obrigatório")
                .EmailAddress()
                .WithMessage("Endereço de email inválido");

            RuleFor(d => d.Document)
                .NotEmpty()
                .WithMessage("Informe o documemnto")
                .Must(IsCpfValid)
                .WithMessage("Documento inválido");
        }

        public static bool IsCpfValid(string cpf)
        {
            while (cpf.Length < 11)
                cpf = "0" + cpf;
            var multiplicador1 = new[] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            var multiplicador2 = new[] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "").Replace("/", "");
            if (cpf.Length != 11)
                return false;
            var CpfTemporario = cpf.Substring(0, 9);
            var soma = 0;
            for (var i = 0; i < 9; i++)
                soma += int.Parse(CpfTemporario[i].ToString()) * multiplicador1[i];
            var resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else resto = 11 - resto;
            var digito = resto.ToString();
            CpfTemporario = CpfTemporario + digito;
            soma = 0;
            for (var i = 0; i < 10; i++)
                soma += int.Parse(CpfTemporario[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else resto = 11 - resto;
            digito = digito + resto;
            return cpf.EndsWith(digito);
        }
    }
}
