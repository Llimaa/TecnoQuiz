using TecnoQuiz.Domain.Entities;

namespace TecnoQuiz.Domain.Repositories
{
    public interface IQuestionRepository
    {
        Task<IEnumerable<Question>> GetByQuizIdAsync(Guid id);
        Task<Question> GetByIdAsync(Guid id);
        Task AddAsync(Question question);
        Task UpdateAsync(Question question);
        Task RemoveAsync(Guid id);
    }
}