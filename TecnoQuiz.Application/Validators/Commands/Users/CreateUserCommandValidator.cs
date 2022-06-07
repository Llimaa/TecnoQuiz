using FluentValidation;
using System.Text.RegularExpressions;
using TecnoQuiz.Application.Commands.Users.Inputs;

namespace TecnoQuiz.Application.Validators.Commands.Users
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(c => c.FullName)
                .Length(10, 200)
                .WithMessage("O Campo Fullname deve ter entre 10 e 200 caracteres");

            RuleFor(c => c.Email)
                .NotEmpty()
                .WithMessage("O campo Email é obrigatório")
                .EmailAddress()
                .WithMessage("Endereço de email inválido");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Informe a senha")
                .Length(8, 20).WithMessage("Senha deve ter no mínimo 8 e no máximo 20 caractéres")
                .Must(RequireDigit).WithMessage("Senha deve ter pelo menos 1 número")
                .Must(RequiredLowerCase).WithMessage("Senha deve ter pelo menos 1 caracter minúsculo")
                .Must(RequireUppercase).WithMessage("Senha deve ter pelo menos 1 caracter maiúsculo")
                .Must(RequireNonAlphanumeric).WithMessage("Digite pelo menos 1 caracter especial (@ ! & * ...)");

            RuleFor(x => x.ConfirmPassword)
                .NotEmpty().WithMessage("Confirme a senha")
                .Equal(x => x.Password).WithMessage("Senhas não conferem");

            RuleFor(r => r.Role)
                .NotEmpty()
                .WithMessage("Informe uma Role");

            RuleFor(b => b.Birthday)
                .NotEmpty()
                .WithMessage("Informe uma data de nacimento")
                .GreaterThanOrEqualTo(DateTime.Now.AddYears(-12))
                .WithMessage("É necessário ter no minimo 12 anos ou mais para se cadastrar");

            RuleFor(d => d.Document)
                .NotEmpty()
                .WithMessage("Informe o documemnto")
                .Must(IsCpfValid)
                .WithMessage("Documento inválido");



        }

        private bool RequireDigit(string password) => password.Any(p => char.IsDigit(p));
        private bool RequiredLowerCase(string password) => password.Any(x => char.IsLower(x));
        private bool RequireUppercase(string password) => password.Any(x => char.IsUpper(x));
        private bool RequireNonAlphanumeric(string password) => (Regex.IsMatch(password, "(?=.*[@#$%^&+=])"));

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
