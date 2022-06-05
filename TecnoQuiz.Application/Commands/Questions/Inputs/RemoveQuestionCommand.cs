using MediatR;

namespace TecnoQuiz.Application.Commands.Questions.Inputs
{
    public class RemoveQuestionCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
