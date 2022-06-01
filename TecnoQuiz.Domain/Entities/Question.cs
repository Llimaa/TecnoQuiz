namespace TecnoQuiz.Domain.Entities
{
    public class Question : BaseEntity
    {

        public Question()
        {

        }
        
        public Question(Guid quizId, string description)
        {
            QuizId = quizId;
            Description = description;
        }

        public Guid QuizId { get; private set; }
        public string Description { get; private set; }

        public List<Answer> Answers { get; private set; }
    }
}
