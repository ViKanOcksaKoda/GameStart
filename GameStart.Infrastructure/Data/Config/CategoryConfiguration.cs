using GameStart.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameStart.Infrastructure.Data.Config
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd();

            builder.Property(cb => cb.Name)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
