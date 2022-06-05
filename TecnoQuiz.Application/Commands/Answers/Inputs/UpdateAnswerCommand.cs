using MediatR;

namespace TecnoQuiz.Application.Commands.Answers.Inputs
{
    public class UpdateAnswerCommand: IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public bool IsRight { get; set; }
    }
}
