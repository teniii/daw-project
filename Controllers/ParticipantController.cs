using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectAPI.Data;
using ProjectAPI.Models;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using ProjectAPI.Core.IConfiguration;

namespace ProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ParticipantController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpGet]
        public Task<IEnumerable<Participant>> GetParticipants()
        {
            return _unitOfWork.Participants.All();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Participant>> GetParticipant(int id)
        {
            var participant = await _unitOfWork.Participants.GetById(id);
            if (participant == null)
            {
                return NotFound();
            }

            return participant;
        }

        [HttpPost]
        public async Task<ActionResult<Participant>> PostParticipant(Participant participant)
        {
            await _unitOfWork.Participants.Add(participant);
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction("GetParticipant", new { id = participant.id }, participant);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutParticipant(int id, Participant participant)
        {
            if (id != participant.id)
            {
                return BadRequest();
            }

            try
            {
                await _unitOfWork.Participants.Update(participant);
                await _unitOfWork.CompleteAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_unitOfWork.Participants.ParticipantExists(id))
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
                if (_unitOfWork.Participants.ParticipantExists(id))
                {
                    return NotFound();
                }
                else
                {
                    await _unitOfWork.Participants.Delete(id);
                    await _unitOfWork.CompleteAsync();
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