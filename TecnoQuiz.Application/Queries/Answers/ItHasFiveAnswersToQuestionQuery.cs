using MediatR;

namespace TecnoQuiz.Application.Queries.Answers
{
    public class ItHasFiveAnswersToQuestionQuery : IRequest<bool>
    {
        public ItHasFiveAnswersToQuestionQuery(Guid questionId)
        {
            QuestionId = questionId;
        }

        public Guid QuestionId { get; set; }
    }
}
