using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Contracts.Repository;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace Infrastructure.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;

        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }
        public Task<List<GenreItemModel>> GetAll()
        {
            var genres = _genreRepository.GetAll()
                            .OrderBy(g => g.Name)
                            .Select(g => new GenreItemModel { Id = g.Id, Name = g.Name, })
                            .ToList();
            return Task.FromResult(genres);

        }

        public async Task<GenreDetailsModel> GetMovies(int genreId, int page = 1, int pageSize = 100)
        {
            var genres = _genreRepository.GetAll();

            var genre = genres.FirstOrDefault(g => g.Id ==  genreId);

            if (genre == null)  return null;

            var movies = await _genreRepository.GetMoviesByGenreAsync(genreId, page, pageSize);
            return new GenreDetailsModel
            {
                Id = genre.Id,
                Name = genre.Name,
                Movies = movies.Select(m => new MovieCardModel
                {
                    Id = m.Id,
                    Title = m.Title,
                    PosterURL = m.PosterUrl
                }).ToList(),
            };
        }
    }
}
