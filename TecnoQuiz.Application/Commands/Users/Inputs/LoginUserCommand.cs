using MediatR;
using TecnoQuiz.Application.ViewModels;

namespace TecnoQuiz.Application.Commands.Users.Inputs
{
    public class LoginUserCommand: IRequest<LoginViewModel>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
