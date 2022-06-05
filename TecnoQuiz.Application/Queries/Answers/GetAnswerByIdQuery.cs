using MediatR;
using TecnoQuiz.Application.ViewModels;

namespace TecnoQuiz.Application.Queries.Answers
{
    public class GetAnswerByIdQuery : IRequest<AnswerViewModel>
    {
        public Guid Id { get; set; }
    }
}
