using MediatR;

namespace TecnoQuiz.Application.Commands.Questions.Inputs
{
    public class UpdateQuestionCommand:IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
    }
}
