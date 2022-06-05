using MediatR;
using TecnoQuiz.Application.ViewModels;

namespace TecnoQuiz.Application.Queries.Quizzes
{
    public class GetByStatusQuizQuery : IRequest<IList<QuizViewModel>>
    {
        public EQuizStatus status { get; set; }
    }
}
