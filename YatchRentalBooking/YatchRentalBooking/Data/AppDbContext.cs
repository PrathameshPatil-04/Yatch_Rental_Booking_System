using Microsoft.EntityFrameworkCore;
using YachtRentalBooking.Models;
using YatchRentalBooking.Models;

namespace YachtRentalMVC.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Boat> Boats { get; set; }
        public DbSet<Booking> Bookings { get; set; }
    }
}