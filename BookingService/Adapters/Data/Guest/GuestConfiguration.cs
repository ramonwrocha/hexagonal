using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Guest;

public class GuestConfiguration : IEntityTypeConfiguration<GuestEntity>
{
    public void Configure(EntityTypeBuilder<GuestEntity> builder)
    {
        builder.ToTable("Guests");
        builder.HasKey(g => g.Id);
        builder.Property(g => g.Name)
            .IsRequired()
            .HasMaxLength(50);
        builder.Property(g => g.Surname)
            .IsRequired()
            .HasMaxLength(50);
        builder.Property(g => g.Type)
            .IsRequired()
            .HasConversion<string>();

        builder.OwnsOne(x => x.Document)
            .Property(x => x.Number);

        builder.OwnsOne(x => x.Document)
            .Property(x => x.Type);

        builder.OwnsOne(x => x.Email, email =>
        {
            email.Property(x => x.Value)
                .IsRequired()
                .HasMaxLength(50);

            email.HasIndex(e => e.Value)
                .IsUnique();
        });


    }
}
