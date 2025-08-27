using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    [Table("Casts")]
    public class Cast
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Gender { get; set; } = string.Empty;   

        [Required]
        [StringLength(128)]
        public string Name { get; set; } = string.Empty;     

        [Required]
        [StringLength(2084)]
        public string ProfilePath { get; set; } = string.Empty; 

        [Required]
        public string TmdbUrl { get; set; } = string.Empty;

        public ICollection<MovieCast> MovieCasts { get; set; } = new HashSet<MovieCast>();
    }
}
