using MediatR;
using TecnoQuiz.Application.ViewModels;

namespace TecnoQuiz.Application.Queries.Quizzes
{
    public class GetAllQuizQuery : IRequest<IList<QuizViewModel>>
    {

    }
}
