
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ApplicationCore.Entities
{
    [Table("MovieCasts")]
    public class MovieCast
    {
        public int MovieId { get; set; }
        public int CastId { get; set; }
        [Required, StringLength(450)]
        public string Character { get; set; } = string.Empty;
        public Movie? Movie { get; set; }
        public Cast? Cast { get; set; }
    }
}
