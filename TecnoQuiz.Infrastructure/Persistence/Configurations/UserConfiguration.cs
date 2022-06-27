using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TecnoQuiz.Domain.Entities;

namespace TecnoQuiz.Infrastructure.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .ToTable("Users")
                .HasKey(x => x.Id);
        }
    }
}
