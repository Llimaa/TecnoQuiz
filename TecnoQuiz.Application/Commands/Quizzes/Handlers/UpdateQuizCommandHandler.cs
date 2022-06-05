using MediatR;
using TecnoQuiz.Application.Commands.Quizzes.Inputs;
using TecnoQuiz.Domain.Repositories;

namespace TecnoQuiz.Application.Commands.Quizzes.Handlers
{
    public class UpdateQuizCommandHandler : IRequestHandler<UpdateQuizCommand, Unit>
    {
        private readonly IQuizRepository _quizRepository;

        public UpdateQuizCommandHandler(IQuizRepository quizRepository)
        {
            _quizRepository = quizRepository;
        }

        public async Task<Unit> Handle(UpdateQuizCommand request, CancellationToken cancellationToken)
        {
            var quiz = await _quizRepository.GetByIdAsync(request.Id);
            quiz.Update(request.Title, request.Description);
            await _quizRepository.UpdateAsync(quiz);
            return Unit.Value;
        }
    }
}
