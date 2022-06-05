using MediatR;

namespace TecnoQuiz.Application.Queries.Answers
{
    public class ItHasFiveAnswersToQuestionQuery : IRequest<bool>
    {
        public Guid QuestionId { get; set; }
    }
}
