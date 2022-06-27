using MediatR;

namespace TecnoQuiz.Application.Queries.UserAnswers
{
    public class GetTotalWrongQuery : IRequest<int>
    {
        public GetTotalWrongQuery(Guid userId, Guid quizId)
        {
            UserId = userId;
            QuizId = quizId;
        }

        public Guid UserId { get; set; }
        public Guid QuizId { get; set; }
    }
}
