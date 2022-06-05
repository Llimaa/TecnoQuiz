using MediatR;

namespace TecnoQuiz.Application.Commands.UserAnswers.Inputs
{
    public class RemoveUserAnswerCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
