using MediatR;

namespace TecnoQuiz.Application.Commands.Answers.Inputs
{
    public class CreateAnswerCommand : IRequest<Unit>
    {
        public Guid QuestionId { get; set; }
        public string Description { get; set; }
        public bool IsRight { get; set; }
    }
}
