using MediatR;
using TecnoQuiz.Application.Commands.Users.Inputs;
using TecnoQuiz.Domain.Entities;
using TecnoQuiz.Domain.Repositories;

namespace TecnoQuiz.Application.Commands.Users.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = ""; // Gerar hash
            var user = new User(request.FullName, request.Email, passwordHash, request.Role, request.Birthday, request.Document);

            await _userRepository.AddAsync(user);
            return user.Id;
        }
    }
}
