using System.ComponentModel.DataAnnotations;

namespace STMSApi.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
