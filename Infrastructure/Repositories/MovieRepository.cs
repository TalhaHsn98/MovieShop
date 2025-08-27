using ApplicationCore.Contracts.Repository;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class MovieRepository : BaseRepsitory<Movie>, IMovieRepository

    {
        public MovieRepository(MovieShopDbContext dbContext): base(dbContext) { }

        public Task<MovieDetailsModel> GetMovieDetails(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<MovieCardModel>> GetTop30Async()
        {
            return await _dbContext.Movies
                .OrderByDescending(m => m.Revenue)
                .Take(30)
                .Select(m => new MovieCardModel
                {
                    Id = m.Id,
                    Title = m.Title,
                    PosterURL = m.PosterUrl
                }).ToListAsync();

        }


    } 
}
