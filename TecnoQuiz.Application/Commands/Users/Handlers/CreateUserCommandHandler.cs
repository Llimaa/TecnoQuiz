using MediatR;
using TecnoQuiz.Application.Commands.Users.Inputs;
using TecnoQuiz.Domain.Entities;
using TecnoQuiz.Domain.Repositories;
using TecnoQuiz.Domain.Services;

namespace TecnoQuiz.Application.Commands.Users.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;

        public CreateUserCommandHandler(IUserRepository userRepository, IAuthService authService)
        {
            _userRepository = userRepository;
            _authService = authService;
        }

        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = _authService.ComputeSha256Hash(request.Password);
            var user = new User(request.FullName, request.Email, passwordHash, request.Role, request.Birthday, request.Document);

            await _userRepository.AddAsync(user);
            return user.Id;
        }
    }
}
