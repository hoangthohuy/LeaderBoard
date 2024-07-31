
using Microsoft.EntityFrameworkCore;

namespace LeaderBoard.Models
{
    public class LeaderContext : DbContext
    {
        public LeaderContext(DbContextOptions<LeaderContext> options) : base(options)
        {

        }

        public DbSet<Employees> Employees { get; set; }
        public DbSet<Achievements> Achievements { get; set; }
    }
}