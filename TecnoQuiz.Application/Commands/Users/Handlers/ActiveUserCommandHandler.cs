using MediatR;
using TecnoQuiz.Application.Commands.Users.Inputs;
using TecnoQuiz.Domain.Repositories;

namespace TecnoQuiz.Application.Commands.Users.Handlers
{
    public class ActiveUserCommandHandler : IRequestHandler<ActiveUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository;

        public ActiveUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(ActiveUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);

            if (user == null)
                throw new Exception("Usuario não existe na base de dados");

            user.ActiveUser();
            await _userRepository.UpdateAsync(user);
            return Unit.Value;
        }
    }
}
