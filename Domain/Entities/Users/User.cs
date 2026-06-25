namespace AprovadosConcursosApi.Domain.Entities.Users
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Nome { get; set; }
        public string Email { get; set; }

        public string PasswordHash { get; set; }

        // Admin, User, Contractor
        public string Role { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}