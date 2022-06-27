using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TecnoQuiz.Domain.Entities;

namespace TecnoQuiz.Infrastructure.Persistence.Configurations
{
    public class UserAnswerConfiguration : IEntityTypeConfiguration<UserAnswer>
    {
        public void Configure(EntityTypeBuilder<UserAnswer> builder)
        {
            builder
                .ToTable("UserAnswers")
                .HasKey(x => x.Id);

            builder
               .HasOne(x => x.User)
               .WithMany()
               .HasForeignKey(x => x.UserId);

            builder
                .HasOne(x => x.Answer)
                .WithMany()
                .HasForeignKey(x => x.AnswerId);
        }
    }
}
