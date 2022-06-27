using Microsoft.EntityFrameworkCore;
using TecnoQuiz.Domain.Entities;
using TecnoQuiz.Domain.Repositories;

namespace TecnoQuiz.Infrastructure.Persistence.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly TecnoQuizContext _tecnoQuizContext;

        public QuestionRepository(TecnoQuizContext tecnoQuizContext)
        {
            _tecnoQuizContext = tecnoQuizContext;
        }

        public async Task AddAsync(Question question)
        {
            await _tecnoQuizContext.Questions.AddAsync(question);
            await _tecnoQuizContext.SaveChangesAsync();
        }

        public async Task<Question> GetByIdAsync(Guid id)
        {
            var question = await _tecnoQuizContext.Questions.Include(x=> x.Answers).FirstOrDefaultAsync(question => question.Id == id);
            return question;
        }

        public async Task<IEnumerable<Question>> GetByQuizIdAsync(Guid id)
        {
            var question = await _tecnoQuizContext.Questions.Where(question => question.QuizId == id).ToListAsync();
            return question;
        }

        public async Task RemoveAsync(Guid id)
        {
            var question = await GetByIdAsync(id);
            _tecnoQuizContext.Questions.Remove(question);
            await _tecnoQuizContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Question question)
        {
            _tecnoQuizContext.Questions.Update(question);
            await _tecnoQuizContext.SaveChangesAsync();
        }
    }
}
