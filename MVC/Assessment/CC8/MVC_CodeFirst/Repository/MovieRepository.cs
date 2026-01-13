using MVC_CodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static MVC_CodeFirst.Models.MovieContext;
using static MVC_CodeFirst.Models.Movie;

namespace MVC_CodeFirst.Repository
{
    public class MovieRepository:IMovieRepository
    {
        Models.MovieContext db = new Models.MovieContext();

        public IEnumerable<Movie> GetAll()
        {
            return db.Movies.ToList();
        }

        public Movie GetById(int id)
        {
            return db.Movies.Find(id);
        }

        public void Insert(Movie movie)
        {
            db.Movies.Add(movie);
        }

        public void Update(Movie movie)
        {
            db.Entry(movie).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(int id)
        {
            var movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
        }

        public IEnumerable<Movie> GetByYear(int year)
        {
            return db.Movies
                     .Where(m => m.DateOfRelease.Year == year)
                     .ToList();
        }

        public IEnumerable<Movie> GetByDirector(string director)
        {
            return db.Movies
                     .Where(m => m.DirectorName == director)
                     .ToList();
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}