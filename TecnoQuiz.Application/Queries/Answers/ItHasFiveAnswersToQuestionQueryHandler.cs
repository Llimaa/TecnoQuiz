using MediatR;
using TecnoQuiz.Domain.Repositories;

namespace TecnoQuiz.Application.Queries.Answers
{
    public class ItHasFiveAnswersToQuestionQueryHandler : IRequestHandler<ItHasFiveAnswersToQuestionQuery, bool>
    {
        private readonly IAnswerRepository _answerRepository;

        public ItHasFiveAnswersToQuestionQueryHandler(IAnswerRepository answerRepository)
        {
            _answerRepository = answerRepository;
        }

        public async Task<bool> Handle(ItHasFiveAnswersToQuestionQuery request, CancellationToken cancellationToken)
        {
            var result = await _answerRepository.ItHasFiveAnswersToQuestion(request.QuestionId);
            return result;
        }
    }
}
