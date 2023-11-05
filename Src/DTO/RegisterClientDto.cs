using System.ComponentModel.DataAnnotations;

namespace Backend.Src.DTO
{
    public class RegisterClientDto
    {

        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Username { get; set; } = string.Empty;

        [Required]
        [MinLength(8)]
        [MaxLength(16)]
        public string Password { get; set; } = string.Empty;
    }
}