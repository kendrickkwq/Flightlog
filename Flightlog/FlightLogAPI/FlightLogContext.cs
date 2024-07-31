using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class FlightLogContext : IdentityDbContext<ApplicationUser>
{
    public DbSet<FlightLog> FlightLogs { get; set; }

    public FlightLogContext(DbContextOptions<FlightLogContext> options)
        : base(options)
    {
    }
}

public class FlightLog
{
    public int Id { get; set; }
    public string TailNumber { get; set; }
    public string FlightID { get; set; }
    public DateTime Takeoff { get; set; }
    public DateTime Landing { get; set; }
    public TimeSpan Duration { get; set; }
}

public class ApplicationUser : IdentityUser
{
}
