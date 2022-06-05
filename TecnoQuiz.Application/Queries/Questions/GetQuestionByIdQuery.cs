using MediatR;
using TecnoQuiz.Application.ViewModels;

namespace TecnoQuiz.Application.Queries.Questions
{
    public class GetQuestionByIdQuery : IRequest<QuestionViewModel>
    {
        public Guid Id { get; set; }
    }
}
