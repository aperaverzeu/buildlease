namespace Domain.Models
{
    public class ApplicationUser
    {
        public string Id { get; set; } = default!;
        public string PasswordHash { get; set; } = default!;
        public bool IsAdmin { get; set; }
    }
}