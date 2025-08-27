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

        public MovieDetailsModel GetMovieDetails(int id)
        {
            var movie = _movieRepository.GetById(id);

            if (movie != null) 
            {
                var movieDetailsModel = new MovieDetailsModel()
                {
                    Id = movie.Id,
                    PosterURL = movie.PosterUrl,
                    Title = movie.Title,
                    Budget = movie.Budget,
                    Overview = movie.Overview,
                    Tagline = movie.Tagline,
                    Revenue = movie.Revenue
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
