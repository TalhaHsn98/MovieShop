using ApplicationCore.Contracts.Repository;
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
    public class MovieRepository : IMovieRepository

    {
        private readonly MovieShopDbContext _ctx;
        public MovieRepository(MovieShopDbContext ctx)

        { _ctx = ctx; }

        public Task<List<MovieCardModel>> GetTop30Async()
        {
            return _ctx.Movies
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
