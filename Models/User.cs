namespace TodoApp.Models
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateTime Created_At { get; set; }

        public ICollection<Category> Categories { get; set; } = new List<Category>();
    }
}
