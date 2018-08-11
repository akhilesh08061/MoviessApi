using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using moviesApi.Models;

namespace moviesApi.Controllers
{
    [Route("api/Movies")]
    [ApiController]
    [Authorize]
    public class MovieController : ControllerBase
    {
        private readonly MoviesDataContext _context;

        public MovieController(MoviesDataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Movie>> getMovies()    
        {
            return _context.Movies.ToList();
        }

    }
}