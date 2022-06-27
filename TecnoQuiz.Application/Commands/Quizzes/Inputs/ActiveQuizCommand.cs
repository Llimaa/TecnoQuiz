using MediatR;

namespace TecnoQuiz.Application.Commands.Quizzes.Inputs
{
    public class ActiveQuizCommand: IRequest<Unit>
    {
        public ActiveQuizCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
