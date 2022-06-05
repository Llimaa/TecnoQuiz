using MediatR;

namespace TecnoQuiz.Application.Commands.Questions.Inputs
{
    public class CreateQuestionCommand: IRequest<Unit>
    {
        public Guid QuizId { get; set; }
        public string Description { get; set; }
    }
}
