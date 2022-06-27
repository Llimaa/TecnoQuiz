using MediatR;
using TecnoQuiz.Application.ViewModels;

namespace TecnoQuiz.Application.Queries.Questions
{
    public class GetQuestionByIdQuery : IRequest<QuestionViewModel>
    {
        public GetQuestionByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
