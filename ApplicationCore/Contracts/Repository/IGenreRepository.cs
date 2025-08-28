using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Repository
{
    public interface IGenreRepository : IRepository<Genre>
    {
        Task<List<Movie>> GetMoviesByGenreAsync(int genreId, int page = 1, int pageSize = 24);
    }
}
