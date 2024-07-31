namespace LeaderBoard.DTOs
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime DoB { get; set; }
        public bool Gender { get; set; }
        public string? Avatar { get; set; }
        public int Point { get; set; }
    }
}
