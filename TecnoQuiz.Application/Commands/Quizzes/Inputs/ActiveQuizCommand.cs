using MediatR;

namespace TecnoQuiz.Application.Commands.Quizzes.Inputs
{
    public class ActiveQuizCommand: IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
