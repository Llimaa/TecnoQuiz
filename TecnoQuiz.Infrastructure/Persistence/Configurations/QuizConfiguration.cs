using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TecnoQuiz.Domain.Entities;

namespace TecnoQuiz.Infrastructure.Persistence.Configurations
{
    public class QuizConfiguration : IEntityTypeConfiguration<Quiz>
    {
        public void Configure(EntityTypeBuilder<Quiz> builder)
        {
            builder
                .ToTable("Quizzes")
                .HasKey(x => x.Id);

            builder
                .HasOne(u => u.User)
                .WithMany(x=> x.Quizzes)
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Questions)
                .WithOne(x => x.Quiz)
                .HasForeignKey(x => x.QuizId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
