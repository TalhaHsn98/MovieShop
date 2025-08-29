using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Services
{
    public interface IMovieService
    {
        Task<List<MovieCardModel>> Top30Movies();

        Task<MovieDetailsModel> GetMovieDetails(int id);

        Task<List<MovieCardModel>> GetAllMovies();

        Task<List<MovieCardModel>> SearchMovies(string query, int page, int pageSize);

        bool DeleteMovie(int id);
    }
}
