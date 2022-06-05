using MediatR;
using TecnoQuiz.Application.Commands.Quizzes.Inputs;
using TecnoQuiz.Domain.Repositories;

namespace TecnoQuiz.Application.Commands.Quizzes.Handlers
{
    public class ActiveQuizCommandHandler : IRequestHandler<ActiveQuizCommand, Unit>
    {
        private readonly IQuizRepository _quizRepository;

        public ActiveQuizCommandHandler(IQuizRepository quizRepository)
        {
            _quizRepository = quizRepository;
        }

        public async Task<Unit> Handle(ActiveQuizCommand request, CancellationToken cancellationToken)
        {
            var quiz = await _quizRepository.GetByIdAsync(request.Id);

            quiz.ActiveQuiz();
            await _quizRepository.UpdateAsync(quiz);
            return Unit.Value;
        }
    }
}
