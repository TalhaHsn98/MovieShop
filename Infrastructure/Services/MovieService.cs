using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Contracts.Repository;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Infrastructure.Repositories;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Services
{
    public class MovieService : IMovieService
    {

        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository) 
        {
            _movieRepository = movieRepository;
        }

        public bool DeleteMovie(int id)
        {
            var movie = _movieRepository.DeleteById(id);

            if (movie == null) { return false; }

            return true;
        }

        public async Task<MovieDetailsModel> GetMovieDetails(int id)
        {
            var m = await _movieRepository.GetByIdWithDetailsAsync(id);

            if (m != null) 
            {
                var movieDetailsModel = new MovieDetailsModel()
                {
                    Id = m.Id,
                    Title = m.Title,
                    PosterURL = m.PosterUrl,
                    Overview = m.Overview,
                    Tagline = m.Tagline,
                    ReleaseDate = m.ReleaseDate,
                    RunTime = m.RunTime,
                    OriginalLanguage = m.OriginalLanguage,
                    Budget = m.Budget,
                    Revenue = m.Revenue,
                    Price = m.Price,
                    AverageRating = m.Reviews.Select(r => (decimal?)r.Rating).DefaultIfEmpty().Average(),
                    Genres = m.MovieGenres.Select(g => g.Genre.Name).ToList(),
                    Trailers = m.Trailers.Select(t => new TrailerModel { Name = t.Name, TrailerUrl = t.TrailerUrl }).ToList(),
                    Casts = m.MovieCasts.Select(c => new CastModel
                    {
                        Id = c.CastId,
                        Name = c.Cast.Name,
                        Character = c.Character,
                        ProfilePath = c.Cast.ProfilePath
                    }).ToList()
                };

                return movieDetailsModel;
            }

            return null;


        }

        public Task<List<MovieCardModel>> Top30Movies()
        {
           return _movieRepository.GetTop30Async();
            
        }

     
    }
}
