using MediatR;

namespace TecnoQuiz.Application.Commands.UserAnswers.Inputs
{
    public class CreateUserAnswerCommand: IRequest<Unit>
    {
        public Guid UserId { get; set; }
        public Guid AnswerId { get; set; }
    }
}
