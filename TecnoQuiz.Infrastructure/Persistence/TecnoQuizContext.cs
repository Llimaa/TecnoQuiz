using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TecnoQuiz.Domain.Entities;

namespace TecnoQuiz.Infrastructure.Persistence
{
    public class TecnoQuizContext : DbContext
    {
        public TecnoQuizContext(DbContextOptions<TecnoQuizContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<UserAnswer> UserAnswers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
