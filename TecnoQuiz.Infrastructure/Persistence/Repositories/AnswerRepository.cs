using Microsoft.EntityFrameworkCore;
using TecnoQuiz.Domain.Entities;
using TecnoQuiz.Domain.Repositories;

namespace TecnoQuiz.Infrastructure.Persistence.Repositories
{
    public class AnswerRepository : IAnswerRepository
    {
        private readonly TecnoQuizContext _tecnoQuizContext;

        public AnswerRepository(TecnoQuizContext tecnoQuizContext)
        {
            _tecnoQuizContext = tecnoQuizContext;
        }

        public async Task AddAsync(Answer ansuer)
        {
            _tecnoQuizContext.Answers.Add(ansuer);
            await _tecnoQuizContext.SaveChangesAsync();
        }

        public async Task<Answer> GetByIdAsync(Guid id)
        {
            var answer = await _tecnoQuizContext.Answers.FirstOrDefaultAsync(answer => answer.Id == id);
            return answer;
        }

        public async Task<IEnumerable<Answer>> GetByQuestionIdAsync(Guid id)
        {
            var answers = await _tecnoQuizContext.Answers.Where(answer => answer.Id == id).ToListAsync();
            return answers;
        }

        public async Task<bool> ItHasFiveAnswersToQuestion(Guid questionId)
        {
            var count = await _tecnoQuizContext.Answers.CountAsync(answer => answer.QuestionId == questionId);
            return count > 5 ? true : false;
        }

        public async Task RemoveAsync(Guid id)
        {
            var answer = await GetByIdAsync(id);
            _tecnoQuizContext.Answers.Remove(answer);
            await _tecnoQuizContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Answer answer)
        {
            _tecnoQuizContext.Answers.Update(answer);
            await _tecnoQuizContext.SaveChangesAsync();
        }
    }
}

