using TecnoQuiz.Domain.Entities;

namespace TecnoQuiz.Domain.Repositories
{
    public interface IUserAnswerRepository
    {
        Task<int> GetTotalRight(Guid userId, Guid quizId);
        Task<int> GetTotalWrong(Guid userId, Guid quizId);
        Task AddUserAnswer(UserAnswer answer);
        Task RemoveById(Guid id);
    }
}
