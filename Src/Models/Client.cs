namespace Backend.Src.Models
{
    public class Client
    {
        public int Id { get; set; }

        public string Names { get; set; } = null!;

        public string LastNames { get; set; } = null!;

        public string RutOrDni { get; set; } = null!;

        public string Email { get; set; } = null!;

        public int Score { get; set; }
    }
}