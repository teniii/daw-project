using System.Threading.Tasks;
using ProjectAPI.Core.IRepositories;

namespace ProjectAPI.Core.IConfiguration
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        IMovieRepository Movies { get; }

        IParticipantRepository Participants { get; }

        Task CompleteAsync();
    }
}