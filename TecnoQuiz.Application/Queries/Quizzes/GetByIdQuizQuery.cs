using MediatR;
using TecnoQuiz.Application.ViewModels;

namespace TecnoQuiz.Application.Queries.Quizzes
{
    public class GetByIdQuizQuery : IRequest<QuizViewModel>
    {
        public Guid Id { get; set; }
    }
}
