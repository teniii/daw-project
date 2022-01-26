using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProjectAPI.Core.IRepositories;
using ProjectAPI.Data;
using ProjectAPI.Models;

namespace ProjectAPI.Core.Repositories
{
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository
    {
        public MovieRepository(
            MovieContext context,
            ILogger logger
        ) : base(context, logger)
        {

        }

        public bool MovieExists(int id)
        {
            return dbSet.Any(e => e.id == id);
        }

        public List<Movie> Latest()
        {
            return dbSet.Where(e => e.release_date.Year == DateTime.Now.Year).ToList();
        }

        public override async Task<IEnumerable<Movie>> All()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All method error", typeof(MovieRepository));
                return new List<Movie>();
            }
        }

        public override async Task<bool> Update(Movie entity)
        {
            try
            {
                var existingMovie = await dbSet.Where(x => x.id == entity.id)
                                                        .FirstOrDefaultAsync();

                if (existingMovie == null)
                    return await Add(entity);

                existingMovie.title = entity.title;
                existingMovie.release_date = entity.release_date;

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Upsert method error", typeof(MovieRepository));
                return false;
            }
        }

        public override async Task<bool> Delete(int id)
        {
            try
            {
                var exist = await dbSet.Where(x => x.id.ToString() == id.ToString())
                                    .FirstOrDefaultAsync();

                if (exist != null)
                {
                    dbSet.Remove(exist);
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Delete method error", typeof(MovieRepository));
                return false;
            }
        }
    }
}