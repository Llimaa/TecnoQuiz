using MediatR;
using TecnoQuiz.Application.Commands.Answers.Inputs;
using TecnoQuiz.Domain.Repositories;

namespace TecnoQuiz.Application.Commands.Answers.Handlers
{
    public class RemoveAnswerCommandHandler : IRequestHandler<RemoveAnswerCommand, Unit>
    {
        private readonly IAnswerRepository _answerRepository;

        public RemoveAnswerCommandHandler(IAnswerRepository answerRepository)
        {
            _answerRepository = answerRepository;
        }

        public async Task<Unit> Handle(RemoveAnswerCommand request, CancellationToken cancellationToken)
        {
            await _answerRepository.RemoveAsync(request.Id);
            return Unit.Value;
        }
    }
}
