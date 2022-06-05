using MediatR;
using TecnoQuiz.Application.Commands.Users.Inputs;
using TecnoQuiz.Domain.Repositories;

namespace TecnoQuiz.Application.Commands.Users.Handlers
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);

            if (user == null)
                throw new Exception("Usuario não existe na base de dados");

            user.Update(request.FullName, request.Email, request.Birthday, request.Document);

            await _userRepository.UpdateAsync(user);
            return Unit.Value;
        }
    }
}
