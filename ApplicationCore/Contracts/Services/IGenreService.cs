using ApplicationCore.Entities;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Services
{
    public interface IGenreService
    {

        Task<List<GenreItemModel>> GetAll();                          
        Task<GenreDetailsModel> GetMovies(int genreId, int page = 1, int pageSize = 100);
                                             
    }
}
