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
        public Task<List<MovieCardModel>> Top30Movies()
        {
           return _movieRepository.GetTop30Async();
            
        }
    }
}
