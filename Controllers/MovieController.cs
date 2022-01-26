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
    public class MovieController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public MovieController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public Task<IEnumerable<Movie>> GetMovies()
        {
            return _unitOfWork.Movies.All();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
            var movie = await _unitOfWork.Movies.GetById(id);
            if (movie == null)
            {
                return NotFound();
            }

            return movie;
        }


        [HttpGet("latest")]
        public List<Movie> GetLatestMovies()
        {
            return _unitOfWork.Movies.Latest();
        }



        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(Movie movie)
        {
            await _unitOfWork.Movies.Add(movie);
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction("GetMovie", new { id = movie.id }, movie);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, Movie movie)
        {
            if (id != movie.id)
            {
                return BadRequest();
            }

            try
            {
                await _unitOfWork.Movies.Update(movie);
                await _unitOfWork.CompleteAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_unitOfWork.Movies.MovieExists(id))
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
        public async Task<IActionResult> DeleteMovie(int id)
        {
            try
            {

                if (!_unitOfWork.Movies.MovieExists(id))
                {
                    return NotFound();
                }
                else
                {
                    await _unitOfWork.Movies.Delete(id);
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