using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int Id { get; set; }

        public DateTime? DateOfBirth { get; set; }

        [Required]
        [StringLength(256)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(128)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(1024)]
        public string HashedPassword { get; set; } = string.Empty;

        [Required]
        public bool IsLocked { get; set; }

        [Required]
        [StringLength(128)]
        public string LastName { get; set; } = string.Empty;

        [StringLength(16)]
        public string? PhoneNumber { get; set; }

        public string? ProfilePictureUrl { get; set; }

        [Required]
        [StringLength(1024)]
        public string Salt { get; set; } = string.Empty;


        public ICollection<Favorite> Favorites { get; set; } = new HashSet<Favorite>();
        public ICollection<Review> Reviews { get; set; } = new HashSet<Review>();
        public ICollection<Purchase> Purchases { get; set; } = new HashSet<Purchase>();
        public ICollection<UserRole> UserRoles { get; set; } = new HashSet<UserRole>();
    }
}
