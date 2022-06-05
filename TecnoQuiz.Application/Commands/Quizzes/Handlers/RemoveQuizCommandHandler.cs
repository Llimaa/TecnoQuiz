using MediatR;
using TecnoQuiz.Application.Commands.Quizzes.Inputs;
using TecnoQuiz.Domain.Repositories;

namespace TecnoQuiz.Application.Commands.Quizzes.Handlers
{
    public class RemoveQuizCommandHandler : IRequestHandler<RemoveQuizCommand, Unit>
    {
        private readonly IQuizRepository _quizRepository;

        public RemoveQuizCommandHandler(IQuizRepository quizRepository)
        {
            _quizRepository = quizRepository;
        }

        public async Task<Unit> Handle(RemoveQuizCommand request, CancellationToken cancellationToken)
        {
            await _quizRepository.RemoveAsync(request.Id);
            return Unit.Value;
        }
    }
}
