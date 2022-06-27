using MediatR;

namespace TecnoQuiz.Application.Commands.Questions.Inputs
{
    public class CreateQuestionCommand: IRequest<Guid>
    {
        public Guid QuizId { get; set; }
        public string Description { get; set; }
    }
}
