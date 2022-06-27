using MediatR;
using TecnoQuiz.Application.ViewModels;

namespace TecnoQuiz.Application.Queries.Answers
{
    public class GetAnswerByQuestionIdQuery: IRequest<IList<AnswerViewModel>>
    {
        public GetAnswerByQuestionIdQuery(Guid questionId)
        {
            QuestionId = questionId;
        }

        public Guid QuestionId { get; set; }
    }
}
