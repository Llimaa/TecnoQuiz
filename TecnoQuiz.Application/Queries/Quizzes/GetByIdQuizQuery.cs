using MediatR;
using TecnoQuiz.Application.ViewModels;

namespace TecnoQuiz.Application.Queries.Quizzes
{
    public class GetByIdQuizQuery : IRequest<QuizViewModel>
    {
        public GetByIdQuizQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
