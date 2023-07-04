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

        //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //        {
        //            if (!optionsBuilder.IsConfigured)
        //            {
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        //                optionsBuilder.UseSqlServer("server = ZSCHN01LP0460; user = sa; password = Password@123; database = TradingJournal");
        //            }
        //        }

    }
}
