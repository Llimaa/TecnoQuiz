namespace TecnoQuiz.Domain.Entities
{
    public class UserAnswer : BaseEntity
    {
        public UserAnswer()
        {

        }
        public UserAnswer(Guid userId, Guid answerId)
        {
            UserId = userId;
            AnswerId = answerId;
        }

        public Guid UserId { get; private set; }
        public Guid AnswerId { get; private set; }

        public List<Answer> Answers { get; private set; }
    }
}
