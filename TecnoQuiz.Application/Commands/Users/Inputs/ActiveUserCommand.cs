using MediatR;

namespace TecnoQuiz.Application.Commands.Users.Inputs
{
    public class ActiveUserCommand: IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
