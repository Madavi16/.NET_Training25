using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MVC_CodeFirst.Models
{
    public class MovieContext:DbContext
    {
      
            public MovieContext() : base("name=MoviesDBConn") { }

            public DbSet<Movie> Movies { get; set; }
        

    }
}