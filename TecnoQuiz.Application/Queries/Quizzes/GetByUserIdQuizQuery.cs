using MediatR;
using TecnoQuiz.Application.ViewModels;

namespace TecnoQuiz.Application.Queries.Quizzes
{
    public class GetByUserIdQuizQuery : IRequest<IList<QuizViewModel>>
    {
        public Guid UserId { get; set; }
    }
}
