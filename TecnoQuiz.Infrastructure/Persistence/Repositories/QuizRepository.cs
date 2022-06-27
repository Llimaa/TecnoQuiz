using Microsoft.EntityFrameworkCore;
using TecnoQuiz.Domain.Entities;
using TecnoQuiz.Domain.Repositories;

namespace TecnoQuiz.Infrastructure.Persistence.Repositories
{
    public class QuizRepository : IQuizRepository
    {
        private readonly TecnoQuizContext _tecnoQuizContex;

        public QuizRepository(TecnoQuizContext tecnoQuizContex)
        {
            _tecnoQuizContex = tecnoQuizContex;
        }

        public async Task AddAsync(Quiz quiz)
        {
            await _tecnoQuizContex.Quizzes.AddAsync(quiz);
            await _tecnoQuizContex.SaveChangesAsync();
        }

        public async Task<IEnumerable<Quiz>> GetAllAsync()
        {
            var quizzes = await _tecnoQuizContex.Quizzes.Include(x => x.User).Include(x => x.Questions).ToListAsync();
            return quizzes;
        }

        public async Task<Quiz> GetByIdAsync(Guid id)
        {
            var quiz = await _tecnoQuizContex.Quizzes.Include(x => x.User).Include(x => x.Questions).FirstOrDefaultAsync(quiz => quiz.Id == id);
            return quiz;
        }

        public async Task<IEnumerable<Quiz>> GetByStatusAsync(EQuizStatus status)
        {
            var quizzes = await _tecnoQuizContex.Quizzes.Include(x => x.User).Include(x => x.Questions).Where(quiz => quiz.Status == status).ToListAsync();
            return quizzes;
        }

        public async Task<IEnumerable<Quiz>> GetByUserIdAsync(Guid id)
        {
            var quizzes = await _tecnoQuizContex.Quizzes
            .Include(x => x.User)
            .Include(x => x.Questions)
                .ThenInclude(y => y.Answers)
            .Where(quiz => quiz.UserId == id).ToListAsync();
            return quizzes;
        }

        public async Task ActiveAsync(Guid id)
        {
            var quiz = await GetByIdAsync(id);
            quiz.ActiveQuiz();
            _tecnoQuizContex.Quizzes.Update(quiz);
            await _tecnoQuizContex.SaveChangesAsync();
        }


        public async Task InactiveAsync(Guid id)
        {
            var quiz = await GetByIdAsync(id);
            quiz.InactiveQuiz();
            _tecnoQuizContex.Quizzes.Update(quiz);
            await _tecnoQuizContex.SaveChangesAsync();
        }

        public async Task RemoveAsync(Guid id)
        {
            var quiz = await GetByIdAsync(id);
            _tecnoQuizContex.Quizzes.Remove(quiz);
            await _tecnoQuizContex.SaveChangesAsync();


        }

        public async Task UpdateAsync(Quiz quiz)
        {
            _tecnoQuizContex.Quizzes.Update(quiz);
            await _tecnoQuizContex.SaveChangesAsync();
        }
    }
}
