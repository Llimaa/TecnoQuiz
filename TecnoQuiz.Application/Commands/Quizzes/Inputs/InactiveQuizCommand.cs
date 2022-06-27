using MediatR;

namespace TecnoQuiz.Application.Commands.Quizzes.Inputs
{
    public class InactiveQuizCommand : IRequest<Unit>
    {
        public InactiveQuizCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
