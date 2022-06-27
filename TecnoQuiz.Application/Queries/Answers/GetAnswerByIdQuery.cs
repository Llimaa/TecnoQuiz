using MediatR;
using TecnoQuiz.Application.ViewModels;

namespace TecnoQuiz.Application.Queries.Answers
{
    public class GetAnswerByIdQuery : IRequest<AnswerViewModel>
    {
        public GetAnswerByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
