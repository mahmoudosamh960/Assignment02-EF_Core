using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class EventConfiguration : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Title).IsRequired().HasMaxLength(200);
        builder.Property(e => e.Description).IsRequired();

        builder.HasOne(e => e.Organizer)
               .WithMany(o => o.Events)
               .HasForeignKey(e => e.OrganizerId);
    }
}

public class BadgeConfiguration : IEntityTypeConfiguration<Badge>
{
    public void Configure(EntityTypeBuilder<Badge> builder)
    {
        builder.HasKey(b => b.Id);
        builder.HasIndex(b => b.BadgeNumber).IsUnique();

        builder.HasOne(b => b.Attendee)
               .WithOne(a => a.Badge)
               .HasForeignKey<Badge>(b => b.AttendeeId);
    }
}