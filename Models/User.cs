using System.ComponentModel.DataAnnotations;

namespace TodoApp.Models
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; } = null!;
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Password minimum 8 length")]
        public string Password { get; set; } = null!;
        public DateTime Created_At { get; set; }

        public ICollection<Category> Categories { get; set; } = new List<Category>();
    }
}
