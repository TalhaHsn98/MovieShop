using ApplicationCore.Entities;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Repository
{
    public interface IMovieRepository: IRepository<Movie>
    {
        Task<List<MovieCardModel>> GetTop30Async();

        Task<MovieDetailsModel> GetMovieDetails(int id);
    }
}
