using TecnoQuiz.Domain.Entities;

namespace TecnoQuiz.Domain.Repositories
{
    public interface IUserAnswerRepository
    {
        Task<int> GetTotalRight(Guid userId, Guid questionId);
        Task<int> GetTotalWrong(Guid userId, Guid questionId);
        Task<IEnumerable<Answer>> GetAnswers(Guid userId, Guid questionId);
        Task RemoveById(Guid id);
        Task Remove(Guid userId, Guid questionId, Guid AnswerId);
    }
}