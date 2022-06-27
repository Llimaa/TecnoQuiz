using MediatR;

namespace TecnoQuiz.Application.Commands.Quizzes.Inputs
{
    public class RemoveQuizCommand: IRequest<Unit>
    {
        public RemoveQuizCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
