using Microsoft.EntityFrameworkCore;
using TecnoQuiz.Domain.Entities;
using TecnoQuiz.Domain.Repositories;

namespace TecnoQuiz.Infrastructure.Persistence.Repositories
{
    public class UserAnswerRepository : IUserAnswerRepository
    {
        private readonly TecnoQuizContext _tecnoQuizContext;

        public UserAnswerRepository(TecnoQuizContext tecnoQuizContext)
        {
            _tecnoQuizContext = tecnoQuizContext;
        }

        public async Task AddUserAnswer(UserAnswer answer)
        {
            await _tecnoQuizContext.UserAnswers.AddAsync(answer);
            await _tecnoQuizContext.SaveChangesAsync();
        }

        public async Task<int> GetTotalRight(Guid userId, Guid quizId)
        {
            var total = await _tecnoQuizContext.UserAnswers
                .Where(x => x.UserId == userId)
                .Include(y => y.Answer)
                .Where(x => x.Answer.IsRight == true)
                .Include(x => x.Answer.Question)
                .CountAsync(x => x.Answer.Question.QuizId == quizId);


            return total;
        }

        public async Task<int> GetTotalWrong(Guid userId, Guid quizId)
        {
            var total = await _tecnoQuizContext.UserAnswers
                           .Where(x => x.UserId == userId)
                           .Include(y => y.Answer)
                           .Where(x => x.Answer.IsRight == false)
                           .Include(x => x.Answer.Question)
                           .CountAsync(x => x.Answer.Question.QuizId == quizId);


            return total;
        }

        public async Task RemoveById(Guid id)
        {
            var userAnswer = await _tecnoQuizContext.UserAnswers.FirstOrDefaultAsync(x => x.Id == id);
            _tecnoQuizContext.UserAnswers.Remove(userAnswer);
            await _tecnoQuizContext.SaveChangesAsync();
        }
    }
}
