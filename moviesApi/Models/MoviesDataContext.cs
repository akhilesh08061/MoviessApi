using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace moviesApi.Models
{
    public class MoviesDataContext:DbContext
    {
        public MoviesDataContext(DbContextOptions<MoviesDataContext> options):base(options)
        {

        }
        public DbSet<Movie> Movies { get; set; }
    }
}
