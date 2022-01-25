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

namespace ProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {

        private MovieContext db = new MovieContext();

        private bool MovieExists(int id)
        {
            return db.Movies.Any(e => e.id == id);
        }

        [HttpGet]
        public List<Movie> GetMovies()
        {
            return db.Movies.ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
            var movie = await db.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            return movie;
        }


        [HttpGet("latest")]
        public List<Movie> GetLatestMovies()
        {
            return db.Movies.Where(movie => movie.release_date.Year == DateTime.Now.Year).ToList();
        }



        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(Movie movie)
        {
            db.Movies.Add(movie);
            await db.SaveChangesAsync();

            return CreatedAtAction("GetMovie", new { id = movie.id }, movie);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, Movie movie)
        {
            if (id != movie.id)
            {
                return BadRequest();
            }

            db.Entry(movie).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
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
                var movie = db.Movies.FirstOrDefault(m => m.id == id);

                if (movie == null)
                {
                    return NotFound();
                }
                else
                {
                    db.Movies.Remove(movie);
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