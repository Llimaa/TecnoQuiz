using MediatR;

namespace TecnoQuiz.Application.Commands.Quizzes.Inputs
{
    public class UpdateQuizCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
