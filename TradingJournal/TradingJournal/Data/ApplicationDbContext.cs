using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using TradingJournal.Models;

namespace TradingJournal.Data
{
    public class ApplicationDbContext : DbContext 
    {
       
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<UserRegistration> userRegistrations { get; set; } = default!;

        public DbSet<Journal> journals { get; set; } = default!;

    }
}
