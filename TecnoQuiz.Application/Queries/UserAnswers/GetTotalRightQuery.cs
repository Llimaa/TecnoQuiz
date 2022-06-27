using MediatR;
namespace TecnoQuiz.Application.Queries.UserAnswers
{
    public class GetTotalRightQuery : IRequest<int>
    {
        public GetTotalRightQuery(Guid userId, Guid quizId)
        {
            UserId = userId;
            QuizId = quizId;
        }

        public Guid UserId { get; set; }
        public Guid QuizId { get; set; }
    }
}
