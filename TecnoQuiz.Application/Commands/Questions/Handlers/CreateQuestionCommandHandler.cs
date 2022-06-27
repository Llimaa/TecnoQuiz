using MediatR;
using TecnoQuiz.Application.Commands.Questions.Inputs;
using TecnoQuiz.Domain.Entities;
using TecnoQuiz.Domain.Repositories;

namespace TecnoQuiz.Application.Commands.Questions.Handlers
{
    internal class CreateQuestionCommandHandler : IRequestHandler<CreateQuestionCommand, Guid>
    {
        private readonly IQuestionRepository _questionRepository;
        public CreateQuestionCommandHandler(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public async Task<Guid> Handle(CreateQuestionCommand request, CancellationToken cancellationToken)
        {
            var question = new Question(request.QuizId, request.Description);
            await _questionRepository.AddAsync(question);
            return question.Id;
        }
    }
}
