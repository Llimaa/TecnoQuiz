using TecnoQuiz.Domain.Entities;

namespace TecnoQuiz.Domain.Repositories
{
    public interface IQuizRepository
    {
        Task<IEnumerable<Quiz>> GetAllAsync();
        Task<IEnumerable<Quiz>> GetByUserIdAsync(Guid id);
        Task<IEnumerable<Quiz>> GetByStatusAsync(EQuizStatus status);
        Task<Quiz> GetByIdAsync(Guid id);
        Task AddAsync(Quiz quiz);
        Task UpdateAsync(Quiz quiz);
        Task ActiveAsync(Guid id);
        Task InactiveAsync(Guid id);
        Task RemoveAsync(Guid id);


    }
}
