using MediatR;
using TecnoQuiz.Application.Commands.Quizzes.Inputs;
using TecnoQuiz.Domain.Entities;
using TecnoQuiz.Domain.Repositories;

namespace TecnoQuiz.Application.Commands.Quizzes.Handlers
{
    public class CreateQuizCommandHandler : IRequestHandler<CreateQuizCommand, Guid>
    {
        private readonly IQuizRepository _quizRepository;

        public CreateQuizCommandHandler(IQuizRepository quizRepository)
        {
            _quizRepository = quizRepository;
        }

        public async Task<Guid> Handle(CreateQuizCommand request, CancellationToken cancellationToken)
        {
            var quiz = new Quiz(request.Title, request.Description, request.UserId);

            await _quizRepository.AddAsync(quiz);
            return quiz.Id;
        }
    }
}
