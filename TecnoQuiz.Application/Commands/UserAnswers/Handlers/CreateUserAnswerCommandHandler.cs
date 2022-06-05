using MediatR;
using TecnoQuiz.Application.Commands.UserAnswers.Inputs;
using TecnoQuiz.Domain.Entities;
using TecnoQuiz.Domain.Repositories;

namespace TecnoQuiz.Application.Commands.UserAnswers.Handlers
{
    public class CreateUserAnswerCommandHandler : IRequestHandler<CreateUserAnswerCommand, Unit>
    {
        private readonly IUserAnswerRepository _userAnswerRepository;

        public CreateUserAnswerCommandHandler(IUserAnswerRepository userAnswerRepository)
        {
            _userAnswerRepository = userAnswerRepository;
        }

        public async Task<Unit> Handle(CreateUserAnswerCommand request, CancellationToken cancellationToken)
        {
            var userAnswr = new UserAnswer(request.UserId, request.AnswerId);
            await _userAnswerRepository.AddUserAnswer(userAnswr);
            return Unit.Value;
        }
    }
}
