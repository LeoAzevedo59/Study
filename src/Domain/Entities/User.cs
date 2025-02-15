using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("users")]
    public class User
    {
        [Key][Column("id")] public Guid Id { get; set; }

        [Column("name")] public string Name { get; set; } = string.Empty;

        [Column("email")] public string Email { get; set; } = string.Empty;

        [Column("password")]
        public string Password { get; set; } = string.Empty;

        [Column("role")] public string Role { get; set; } = string.Empty;
    }
}
