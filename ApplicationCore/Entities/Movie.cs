using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    [Table("Movies")]
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [StringLength(2084)]
        public string? BackdropUrl { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal? Budget { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(2084)]
        public string? ImdbUrl { get; set; }

        [StringLength(64)]
        public string? OriginalLanguage { get; set; }

        public string? Overview { get; set; }

        [StringLength(2084)]
        public string? PosterUrl { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal? Price { get; set; }

        public DateTime? ReleaseDate { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal? Revenue { get; set; }

        public int? RunTime { get; set; }

        [StringLength(512)]
        public string? Tagline { get; set; }

        [StringLength(256)]
        public string? Title { get; set; }

        [StringLength(2084)]
        public string? TmdbUrl { get; set; }

        public string? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }


        public ICollection<MovieGenre> MovieGenres { get; set; } = new HashSet<MovieGenre>();
        public ICollection<MovieCast> MovieCasts { get; set; } = new HashSet<MovieCast>();
        public ICollection<Trailer> Trailers { get; set; } = new HashSet<Trailer>();
        public ICollection<Favorite> Favorites { get; set; } = new HashSet<Favorite>();
        public ICollection<Review> Reviews { get; set; } = new HashSet<Review>();
        public ICollection<Purchase> Purchases { get; set; } = new HashSet<Purchase>();
    }
}
