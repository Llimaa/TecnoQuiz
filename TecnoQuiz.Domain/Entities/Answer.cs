namespace TecnoQuiz.Domain.Entities
{
    public class Answer : BaseEntity
    {
        public Answer()
        {

        }
        public Answer(Guid questionId, string description,bool isRight)
        {
            QuestionId = questionId;
            Description = description;
            IsRight = isRight;
        }

        public Guid QuestionId { get; private set; }
        public string Description { get; private set; }
        public bool IsRight { get; private set; }
    }
}