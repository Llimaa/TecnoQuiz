using MediatR;

namespace TecnoQuiz.Application.Commands.Quizzes.Inputs
{
    public class RemoveQuizCommand: IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
