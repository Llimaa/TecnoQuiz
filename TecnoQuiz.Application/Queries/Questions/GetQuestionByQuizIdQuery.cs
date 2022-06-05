using MediatR;
using TecnoQuiz.Application.ViewModels;

namespace TecnoQuiz.Application.Queries.Questions
{
    public class GetQuestionByQuizIdQuery : IRequest<IList<QuestionViewModel>>
    {
        public Guid QuizId { get; set; }
    }
}
