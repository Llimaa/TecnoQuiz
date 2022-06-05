using MediatR;
using TecnoQuiz.Application.Commands.Quizzes.Inputs;
using TecnoQuiz.Domain.Repositories;

namespace TecnoQuiz.Application.Commands.Quizzes.Handlers
{
    public class InactiveQuizCommandHandler : IRequestHandler<InactiveQuizCommand, Unit>
    {
        private readonly IQuizRepository _quizRepository;

        public InactiveQuizCommandHandler(IQuizRepository quizRepository)
        {
            _quizRepository = quizRepository;
        }

        public async Task<Unit> Handle(InactiveQuizCommand request, CancellationToken cancellationToken)
        {
            var quiz = await _quizRepository.GetByIdAsync(request.Id);
            quiz.InactiveQuiz();
            await _quizRepository.UpdateAsync(quiz);
            return Unit.Value;
        }
    }
}
