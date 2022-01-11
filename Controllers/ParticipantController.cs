using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectAPI.Models;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

namespace ProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantController : ControllerBase
    {

        private MovieContext db = new MovieContext();

        private bool ParticipantExists(int id)
        {
            return db.Participants.Any(e => e.id == id);
        }

        [HttpGet]
        public List<Participant> GetParticipants()
        {
            return db.Participants.ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Participant>> GetParticipant(int id)
        {
            var participant = await db.Participants.FindAsync(id);
            if (participant == null)
            {
                return NotFound();
            }

            return participant;
        }

        [HttpPost]
        public async Task<ActionResult<Participant>> PostParticipant(Participant participant)
        {
            db.Participants.Add(participant);
            await db.SaveChangesAsync();

            return CreatedAtAction("GetParticipant", new { id = participant.id }, participant);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutParticipant(int id, Participant participant)
        {
            if (id != participant.id)
            {
                return BadRequest();
            }

            db.Entry(participant).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParticipantExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParticipant(int id)
        {
            try
            {
                var participant = db.Participants.FirstOrDefault(m => m.id == id);

                if (participant == null)
                {
                    return NotFound();
                }
                else
                {
                    db.Participants.Remove(participant);
                    await db.SaveChangesAsync();
                    return Ok();
                }
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

    }
}