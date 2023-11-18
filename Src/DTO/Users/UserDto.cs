using Backend.Src.Models;

namespace Backend.Src.DTO.Users
{
    public class UserDto
    {
        public int Id { get; set; }

        public string Username { get; set; } = null!;

        public int RoleId { get; set; }

        public Role Role { get; set; } = null!;
    }
}