using MediatR;
using TecnoQuiz.Application.Commands.Questions.Inputs;
using TecnoQuiz.Domain.Repositories;

namespace TecnoQuiz.Application.Commands.Questions.Handlers
{
    public class RemoveQuestionCommandHandler : IRequestHandler<RemoveQuestionCommand, Unit>
    {
        private readonly IQuestionRepository _questionRepository;

        public RemoveQuestionCommandHandler(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public async Task<Unit> Handle(RemoveQuestionCommand request, CancellationToken cancellationToken)
        {
            await _questionRepository.RemoveAsync(request.Id);
            return Unit.Value;
        }
    }
}
