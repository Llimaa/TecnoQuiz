using MediatR;
using TecnoQuiz.Application.Commands.Answers.Inputs;
using TecnoQuiz.Domain.Entities;
using TecnoQuiz.Domain.Repositories;

namespace TecnoQuiz.Application.Commands.Answers.Handlers
{
    internal class CreateAnswerCommandHandler : IRequestHandler<CreateAnswerCommand, Unit>
    {
        private readonly IAnswerRepository _answerRepository;

        public CreateAnswerCommandHandler(IAnswerRepository answerRepository)
        {
            _answerRepository = answerRepository;
        }

        public async Task<Unit> Handle(CreateAnswerCommand request, CancellationToken cancellationToken)
        {
            var itHasFiveQuestion = await _answerRepository.ItHasFiveAnswersToQuestion(request.QuestionId);

            if (itHasFiveQuestion)
                throw new Exception("Não pode ser cadastrado mais de 5 resposta por pergunta!");

            var answer = new Answer(request.QuestionId, request.Description, request.IsRight);
            await _answerRepository.AddAsync(answer);

            return Unit.Value;
        }
    }
}
