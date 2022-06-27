using MediatR;
using TecnoQuiz.Application.ViewModels;

namespace TecnoQuiz.Application.Queries.Quizzes
{
    public class GetByStatusQuizQuery : IRequest<IList<QuizViewModel>>
    {
        public GetByStatusQuizQuery(EQuizStatus status)
        {
            this.status = status;
        }

        public EQuizStatus status { get; set; }
    }
}
