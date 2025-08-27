using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    [Table("Trailers")]
    public class Trailer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int MovieId { get; set; }
        [Required, StringLength(2084)]
        public string Name { get; set; } = string.Empty;
        [Required, StringLength(2084)]
        public string TrailerUrl { get; set; } = string.Empty;
        public Movie? Movie { get; set; }
    }

}
