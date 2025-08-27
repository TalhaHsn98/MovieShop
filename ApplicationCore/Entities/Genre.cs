using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    [Table("Genres")]
    public class Genre
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(24)]           
        public string Name { get; set; } = string.Empty;

        public ICollection<MovieGenre> MovieGenres { get; set; } = new HashSet<MovieGenre>();
    }
}
