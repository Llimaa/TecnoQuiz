using TecnoQuiz.Domain.Entities;

namespace TecnoQuiz.Domain.Repositories
{
    public interface IAnswerRepository
    {
        Task<IEnumerable<Answer>> GetByQuestionIdAsync(Guid id);
        Task<Answer> GetByIdAsync(Guid id);

        Task AddAsync(Answer ansuer);
        Task UpdateAsync(Answer answer);
        Task RemoveAsync(Guid id);
    }
}
