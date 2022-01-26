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
    public class ParticipantRepository : GenericRepository<Participant>, IParticipantRepository
    {
        public ParticipantRepository(
            MovieContext context,
            ILogger logger
        ) : base(context, logger)
        {

        }

        public override async Task<IEnumerable<Participant>> All()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All method error", typeof(ParticipantRepository));
                return new List<Participant>();
            }
        }

        public override async Task<bool> Update(Participant entity)
        {
            try
            {
                var existingParticipant = await dbSet.Where(x => x.id == entity.id)
                                                        .FirstOrDefaultAsync();

                if (existingParticipant == null)
                    return await Add(entity);

                existingParticipant.name = entity.name;
                existingParticipant.surname = entity.surname;
                existingParticipant.date_of_birth = entity.date_of_birth;
                existingParticipant.fan_mail_address = entity.fan_mail_address;

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Upsert method error", typeof(ParticipantRepository));
                return false;
            }
        }

        public override async Task<bool> Delete(Guid id)
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
                _logger.LogError(ex, "{Repo} Delete method error", typeof(ParticipantRepository));
                return false;
            }
        }
    }
}