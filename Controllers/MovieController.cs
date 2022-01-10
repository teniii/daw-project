using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectAPI.Services;
using ProjectAPI.Models;

namespace ProjectAPI.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    [ApiController]
    public class MovieController : ControllerBase
    {

        private MovieContext db = new MovieContext();

        [HttpGet]
        public List<Movie> all()
        {
            return db.Movies.ToList();
        }

        [HttpGet]
        public Movie Index(int? id)
        {
            if (id == null)
            {
                return null;
            }

            return db.Movies.Find(id);
        }

    }
}