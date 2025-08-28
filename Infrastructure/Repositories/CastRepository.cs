using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Contracts.Repository;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CastRepository : BaseRepsitory<Cast>, ICastRepository
    {
        public CastRepository(MovieShopDbContext dbContext) : base(dbContext) { }

        public override async Task<Cast?> GetById(int id)
        {
            return await _dbContext.Casts
                .Include(c => c.MovieCasts)
                .ThenInclude(mc => mc.Movie)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
        
            
        

    }
}
