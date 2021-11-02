using api.domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace api.data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("User");

            builder.HasKey(u => u.Id);

            builder.HasIndex(u => u.email)
                .IsUnique();

            builder.Property(u => u.name)
                .IsRequired()
                .HasMaxLength(60);

            builder.Property(u => u.email)
                .HasMaxLength(100);

        }
    }
}
