using MediatR;
namespace TecnoQuiz.Application.Commands.Quizzes.Inputs
{
    public class CreateQuizCommand : IRequest<Unit>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid UserId { get; set; }
    }
}
