using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration;

public class BookingGuestConfiguration : IEntityTypeConfiguration<BookingGuestEntity>
{
    public void Configure(EntityTypeBuilder<BookingGuestEntity> builder)
    {
        builder.ToTable("BookingGuests");
        builder.HasKey(bg => new { bg.BookingId, bg.GuestId });

        builder
            .HasOne(bg => bg.Booking)
            .WithMany(b => b.BookingGuests)
            .HasForeignKey(bg => bg.BookingId);

        builder
            .HasOne(bg => bg.Guest)
            .WithMany(g => g.BookingGuests)
            .HasForeignKey(bg => bg.GuestId);

    }
}
