using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TecnoQuiz.Domain.Entities;

namespace TecnoQuiz.Infrastructure.Persistence.Configurations
{
    public class AnswerConfiguration : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> builder)
        {
            builder
                .ToTable("Answers")
                .HasKey(x => x.Id);

            builder
                .HasOne(x => x.Question)
                .WithMany(p => p.Answers)
                .HasForeignKey(x => x.QuestionId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
