using MediatR;

namespace TecnoQuiz.Application.Commands.Quizzes.Inputs
{
    public class InactiveQuizCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
