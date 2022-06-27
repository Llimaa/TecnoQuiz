using MediatR;
using TecnoQuiz.Application.ViewModels;

namespace TecnoQuiz.Application.Queries.Questions
{
    public class GetQuestionByQuizIdQuery : IRequest<IList<QuestionViewModel>>
    {
        public GetQuestionByQuizIdQuery(Guid quizId)
        {
            QuizId = quizId;
        }

        public Guid QuizId { get; set; }
    }
}
