namespace LeaderBoard.Models
{
    public class Achievements
    {
        public int Id { get; set; }
        public string? AchievementName { get; set; }

        public string? Propreties { get; set; }

        public int Point { get; set; }

        public int EmployeeId { get; set; }
    }
}
