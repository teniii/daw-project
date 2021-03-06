using ProjectAPI.Models;

namespace ProjectAPI.Core.IRepositories
{
    public interface IParticipantRepository : IGenericRepository<Participant>
    {
        bool ParticipantExists(int id);
    }
}