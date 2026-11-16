using Microsoft.EntityFrameworkCore;

EventHubContext context = new EventHubContext();

context.Database.EnsureDeleted();
context.Database.EnsureCreated();

Organizer organizer = new Organizer();
organizer.Name = "Ahmed Ali";
organizer.CompanyName = "Route";
organizer.IsVerified = true;

organizer.Profile = new OrganizerProfile();
organizer.Profile.Biography = "Event organizer";
organizer.Profile.Website = "https://route.com";

Event ev = new Event();
ev.Title = "EF Core Workshop";
ev.Description = "Learn EF Core";
ev.StartDate = DateTime.Now.AddDays(5);
ev.MaxAttendees = 50;
organizer.Events.Add(ev);

context.Organizers.Add(organizer);

Attendee attendee = new Attendee();
attendee.FullName = "Sara Hassan";
attendee.Email = "sara@mail.com";
attendee.Street = "12 Nile St";
attendee.City = "Cairo";
attendee.Country = "Egypt";
attendee.PostalCode = "11511";

attendee.Badge = new Badge();
attendee.Badge.BadgeNumber = 1001;
attendee.Badge.IssuedDate = DateTime.Now;
attendee.Badge.Tier = BadgeTier.VIP;

context.Attendees.Add(attendee);

context.SaveChanges();

Console.WriteLine("Data saved successfully");
Console.WriteLine(attendee.FullAddress);
