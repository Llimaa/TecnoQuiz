namespace TecnoQuiz.Domain.Entities
{
    public class UserAnswer : BaseEntity
    {
        public UserAnswer()
        {
            
        }
        public UserAnswer(Guid userId, Guid quizId, Guid questionId, Guid answerId)
        {
            UserId = userId;
            QuizId = quizId;
            QuestionId = questionId;
            AnswerId = answerId;
        }

        public Guid UserId { get; private set; }
        public Guid QuizId { get; private set; }
        public Guid QuestionId { get; private set; }
        public Guid AnswerId { get; private set; }
    }
}
