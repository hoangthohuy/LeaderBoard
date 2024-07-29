using Microsoft.EntityFrameworkCore;


namespace LeaderBoard.Models
{
    public class AchievementsContext : DbContext
    {
        public AchievementsContext(DbContextOptions<AchievementsContext> options) : base(options)
        {

        }

        public DbSet<Achievements> Achievements { get; set; }
    }
}