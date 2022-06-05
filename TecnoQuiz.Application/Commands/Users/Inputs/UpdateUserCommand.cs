using MediatR;

namespace TecnoQuiz.Application.Commands.Users.Inputs
{
    public class UpdateUserCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
        public string Document { get; set; }
    }
}
