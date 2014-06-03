using System;
using System.Collections.Generic;
using System.Data.Entity;
using MvcMovie.Models;

namespace MvcMovie.Models
{
    public class MovieContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
    }
}