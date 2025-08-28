using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Contracts.Repository;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;

namespace Infrastructure.Services
{
    public class CastService : ICastService
    {
        private readonly ICastRepository _castRepository;

        public CastService(ICastRepository castRepository)
        {
            _castRepository = castRepository;
        }
        public async Task<CastDetailsModel?> GetCastDetails(int id)
        {
            var cast = await _castRepository.GetById(id);

            if (cast == null) { return null; }

            return new CastDetailsModel()
            {
                Id = cast.Id,
                Name = cast.Name,
                Gender = cast.Gender,
                ProfilePath = cast.ProfilePath,
                TmdbUrl = cast.TmdbUrl,
                Movies = cast.MovieCasts
                .OrderByDescending(mc => mc.Movie.Revenue)
                .Select(mc => new MovieCardModel
                {
                    Id = mc.MovieId,
                    Title = mc.Movie.Title,
                    PosterURL = mc.Movie.PosterUrl
                })
                .ToList()
            };
        }
    }
}
