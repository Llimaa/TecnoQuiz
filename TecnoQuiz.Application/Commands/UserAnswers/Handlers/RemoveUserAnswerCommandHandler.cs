using MediatR;
using TecnoQuiz.Application.Commands.UserAnswers.Inputs;
using TecnoQuiz.Domain.Repositories;

namespace TecnoQuiz.Application.Commands.UserAnswers.Handlers
{
    public class RemoveUserAnswerCommandHandler : IRequestHandler<RemoveUserAnswerCommand, Unit>
    {
        private readonly IUserAnswerRepository _userAnswerRepository;

        public RemoveUserAnswerCommandHandler(IUserAnswerRepository userAnswerRepository)
        {
            _userAnswerRepository = userAnswerRepository;
        }
        public async Task<Unit> Handle(RemoveUserAnswerCommand request, CancellationToken cancellationToken)
        {
            await _userAnswerRepository.RemoveById(request.Id);
            return Unit.Value;
        }
    }
}
