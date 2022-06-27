
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TecnoQuiz.Domain.Entities;

namespace TecnoQuiz.Infrastructure.Persistence.Configurations
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder
                .ToTable("Questions")
                .HasKey(x => x.Id);

            builder
                .HasOne(q => q.Quiz)
                .WithMany(x => x.Questions)
                .HasForeignKey(x => x.QuizId)
                .OnDelete(DeleteBehavior.Restrict);

            //builder.HasMany(x => x.Answers)
            //    .WithOne()
            //    .HasForeignKey(x => x.QuestionId);

        }
    }
}
