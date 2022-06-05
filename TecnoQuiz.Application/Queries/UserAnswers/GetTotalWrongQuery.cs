using MediatR;

namespace TecnoQuiz.Application.Queries.UserAnswers
{
    public class GetTotalWrongQuery : IRequest<int>
    {
        public Guid UserId { get; set; }
        public Guid QuizId { get; set; }
    }
}
