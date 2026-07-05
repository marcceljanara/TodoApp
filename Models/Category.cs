using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApp.Models
{
    public class Category
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Color_Hex { get; set; } = null!;

    }
}
