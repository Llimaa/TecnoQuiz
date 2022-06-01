namespace TecnoQuiz.Domain.Entities
{
    public class Answer: BaseEntity
    {
        public Answer()
        {
            
        }
        public Answer(Guid questionId, string description)
        {
            QuestionId = questionId;
            Description = description;
        }

        public Guid QuestionId { get; private set; }
        public string Description { get; private set; }
    }
}