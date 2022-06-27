using MediatR;
using TecnoQuiz.Application.Commands.Users.Inputs;
using TecnoQuiz.Application.ViewModels;
using TecnoQuiz.Domain.Repositories;
using TecnoQuiz.Domain.Services;

namespace TecnoQuiz.Application.Commands.Users.Handlers
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginViewModel>
    {
        private readonly IAuthService _authService;
        private IUserRepository _userRepository;

        public LoginUserCommandHandler(IAuthService authService, IUserRepository userRepository)
        {
            _authService = authService;
            _userRepository = userRepository;
        }

        public async Task<LoginViewModel> Handle(LoginUserCommand command, CancellationToken cancellationToken)
        {
            var passwordHash = _authService.ComputeSha256Hash(command.Password);

            var user = await _userRepository.GetByEmailAndPasswordAsync(command.Email, passwordHash);

            if (user == null) return null;

            var roles = user.Role.Split(";");
            var token = _authService.GenerateJwtToken(command.Email, roles.ToList());

            return new LoginViewModel(user.FullName, user.Email, token);
        }
    }
}
