using MediatR;
using TecnoQuiz.Application.Commands.Users.Inputs;
using TecnoQuiz.Domain.Repositories;

namespace TecnoQuiz.Application.Commands.Users.Handlers
{
    public class InactiveUserCommandHandler : IRequestHandler<InactiveUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository;

        public InactiveUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(InactiveUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
