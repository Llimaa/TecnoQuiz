using MediatR;

namespace TecnoQuiz.Application.Commands.Questions.Inputs
{
    public class RemoveQuestionCommand : IRequest<Unit>
    {
        public RemoveQuestionCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
