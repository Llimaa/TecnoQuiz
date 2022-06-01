namespace TecnoQuiz.Domain.Entities
{
    public class Quiz : BaseEntity
    {
        public Quiz()
        {

        }
        public Quiz(string title, string description, Guid userId)
        {
            Title = title;
            Description = description;
            UserId = userId;
            Status = EQuizStatus.Active;
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public EQuizStatus Status { get; private set; }

        public Guid UserId { get; private set; }
        public List<Question> Questions { get; private set; }
    }
}
