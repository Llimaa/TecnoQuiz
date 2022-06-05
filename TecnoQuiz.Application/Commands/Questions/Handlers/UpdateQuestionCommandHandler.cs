using MediatR;
using TecnoQuiz.Application.Commands.Questions.Inputs;
using TecnoQuiz.Domain.Repositories;

namespace TecnoQuiz.Application.Commands.Questions.Handlers
{
    public class UpdateQuestionCommandHandler : IRequestHandler<UpdateQuestionCommand, Unit>
    {
        private readonly IQuestionRepository _questionRepository;

        public UpdateQuestionCommandHandler(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public async Task<Unit> Handle(UpdateQuestionCommand request, CancellationToken cancellationToken)
        {
            var question = await _questionRepository.GetByIdAsync(request.Id);
            question.Update(request.Description);
            return Unit.Value;
        }
    }
}
