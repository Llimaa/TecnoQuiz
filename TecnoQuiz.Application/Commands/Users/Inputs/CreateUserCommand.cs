using MediatR;

namespace TecnoQuiz.Application.Commands.Users.Inputs
{
    public class CreateUserCommand : IRequest<Guid>
    {

        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Role { get; set; }
        public DateTime Birthday { get; set; }
        public string Document { get; set; }
    }
}
