using MediatR;

namespace TecnoQuiz.Application.Commands.Users.Inputs
{
    public class InactiveUserCommand:IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
