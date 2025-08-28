using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class MovieDetailsModel
    {
        public int Id { get; set; } 
        public string Title { get; set; }

        public string PosterURL { get; set; }

        public decimal? Budget { get; set; }
        public string? Overview { get; set; }
        public decimal? Revenue { get; set; }

        public string? Tagline { get; set; }
        public DateTime? ReleaseDate { get; set; }

        public int? RunTime { get; set; }

        public string? OriginalLanguage { get; set; }

        public decimal? Price { get; set; }

        public decimal? AverageRating { get; set; }


        public List<string> Genres { get; set; } = new();
        public List<TrailerModel> Trailers { get; set; } = new();
        public List<CastModel> Casts { get; set; } = new();


    }
}
