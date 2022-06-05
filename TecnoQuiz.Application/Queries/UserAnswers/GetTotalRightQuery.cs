using MediatR;
namespace TecnoQuiz.Application.Queries.UserAnswers
{
    public class GetTotalRightQuery : IRequest<int>
    {
        public Guid UserId { get; set; }
        public Guid QuizId { get; set; }
    }
}
