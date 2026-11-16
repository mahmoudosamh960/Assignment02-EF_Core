using Microsoft.EntityFrameworkCore;

public class EventHubContext : DbContext
{
    public DbSet<Organizer> Organizers { get; set; }
    public DbSet<OrganizerProfile> OrganizerProfiles { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<Attendee> Attendees { get; set; }
    public DbSet<Badge> Badges { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.\\MSSQLSERVER01;Database=EventHubDb;Trusted_Connection=True;TrustServerCertificate=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       
        modelBuilder.Entity<OrganizerProfile>().HasKey(p => p.OrganizerId);

        modelBuilder.Entity<OrganizerProfile>()
            .HasOne(p => p.Organizer)
            .WithOne(o => o.Profile)
            .HasForeignKey<OrganizerProfile>(p => p.OrganizerId);

        modelBuilder.ApplyConfiguration(new EventConfiguration());
        modelBuilder.ApplyConfiguration(new BadgeConfiguration());
    }

}