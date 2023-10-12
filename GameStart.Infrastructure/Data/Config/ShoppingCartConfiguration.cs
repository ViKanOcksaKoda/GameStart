using GameStart.Core.Entities.ShoppingCartAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameStart.Infrastructure.Data.Config
{
    public class ShoppingCartConfiguration : IEntityTypeConfiguration<ShoppingCart>
    {
        public void Configure(EntityTypeBuilder<ShoppingCart> builder)
        {
            var navigation = builder.Metadata.FindNavigation(nameof(ShoppingCart.Items));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.Property(sc => sc.Id)
                .ValueGeneratedOnAdd();

            builder.Property(sc => sc.UserId)
                .IsRequired()
                .HasMaxLength(256);
        }
    }
}
