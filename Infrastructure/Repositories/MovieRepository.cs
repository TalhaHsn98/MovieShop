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

        public async Task<Movie?> GetByIdWithDetailsAsync(int id)
        {
            return await _dbContext.Movies.Where(m => m.Id == id)
               .Include(m => m.MovieGenres).ThenInclude(mg => mg.Genre)
               .Include(m => m.MovieCasts).ThenInclude(mc => mc.Cast)
               .Include(m => m.Trailers)
               .Include(m => m.Reviews)
               .FirstOrDefaultAsync(m => m.Id == id);
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
