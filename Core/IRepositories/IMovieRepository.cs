using ProjectAPI.Models;
using System.Collections.Generic;
namespace ProjectAPI.Core.IRepositories
{
    public interface IMovieRepository : IGenericRepository<Movie>
    {
        bool MovieExists(int id);
        List<Movie> Latest();
    }
}