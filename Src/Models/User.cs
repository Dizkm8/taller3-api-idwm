namespace Backend.Src.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        // Entity Framework
        public int RoleId { get; set; }

        public Role Role { get; set; } = null!;
        
    }
}