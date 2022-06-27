using Microsoft.EntityFrameworkCore;
using TecnoQuiz.Domain.Entities;
using TecnoQuiz.Domain.Repositories;

namespace TecnoQuiz.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TecnoQuizContext _tecnoQuizContext;

        public UserRepository(TecnoQuizContext tecnoQuizContext)
        {
            _tecnoQuizContext = tecnoQuizContext;
        }

        public async Task AddAsync(User user)
        {
            await _tecnoQuizContext.Users.AddAsync(user);
            await _tecnoQuizContext.SaveChangesAsync();
        }

        public async Task<User> GetByEmailAndPasswordAsync(string email, string passwordHash)
        {
            var user = await _tecnoQuizContext.Users.SingleOrDefaultAsync(user => user.Email == email && user.Password == passwordHash);
            return user;
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            var user = await _tecnoQuizContext.Users.FirstOrDefaultAsync(user => user.Email == email);
            return user;
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            var user = await _tecnoQuizContext.Users.FirstOrDefaultAsync(user => user.Id == id);
            return user;
        }

        public async Task UpdateAsync(User user)
        {
            _tecnoQuizContext.Update(user);
            await _tecnoQuizContext.SaveChangesAsync();
        }
    }
}
