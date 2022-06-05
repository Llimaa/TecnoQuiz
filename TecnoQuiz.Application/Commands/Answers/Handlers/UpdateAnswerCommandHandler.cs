using MediatR;
using TecnoQuiz.Application.Commands.Answers.Inputs;
using TecnoQuiz.Domain.Repositories;

namespace TecnoQuiz.Application.Commands.Answers.Handlers
{
    public class UpdateAnswerCommandHandler : IRequestHandler<UpdateAnswerCommand, Unit>
    {
        private readonly IAnswerRepository _answerRepository;

        public UpdateAnswerCommandHandler(IAnswerRepository answerRepository)
        {
            _answerRepository = answerRepository;
        }

        public async Task<Unit> Handle(UpdateAnswerCommand request, CancellationToken cancellationToken)
        {
            var answer = await _answerRepository.GetByIdAsync(request.Id);
            if (answer == null) throw new Exception("Resposta não existe com esse identificador");

            answer.Update(request.Description, request.IsRight);
            return Unit.Value;
        }
    }
}
