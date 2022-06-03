using TecnoQuiz.Domain.Entities;

namespace TecnoQuiz.Domain.Repositories
{
    public interface IUserAnswerRepository
    {
        Task<int> GetTotalRight(Guid userId, Guid quizId);
        Task<int> GetTotalWrong(Guid userId, Guid quizId);
        Task<IEnumerable<Answer>> GetAnswersByQuiz(Guid userId, Guid quizId);
        Task<bool> BeAnswered(Guid userId, Guid questionId);
        Task AddUserAnswer(UserAnswer answer);
        Task RemoveById(Guid id);
    }
}
