using MediatR;

namespace TecnoQuiz.Application.Commands.Answers.Inputs
{
    public class RemoveAnswerCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
