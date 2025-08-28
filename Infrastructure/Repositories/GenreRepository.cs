using ApplicationCore.Contracts.Repository;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class GenreRepository : BaseRepsitory<Genre>, IGenreRepository
    {

        public GenreRepository(MovieShopDbContext context): base(context) 
        {
        }
      

        public async Task<List<Movie>> GetMoviesByGenreAsync(int genreId, int page = 1, int pageSize = 24)
        {
            return await _dbContext.MovieGenres
            .Where(mg => mg.GenreId == genreId)
            .Select(mg => mg.Movie)
            .OrderByDescending(m => m.Revenue)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .AsNoTracking()
            .ToListAsync();
        }
    }
}
