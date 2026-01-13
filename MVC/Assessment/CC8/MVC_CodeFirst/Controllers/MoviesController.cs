using MVC_CodeFirst.Models;
using MVC_CodeFirst.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_CodeFirst.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        IMovieRepository repo = new MovieRepository();

        public ActionResult Index()
        {
            return View(repo.GetAll());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            repo.Insert(movie);
            repo.Save();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            return View(repo.GetById(id));
        }

        [HttpPost]
        public ActionResult Edit(Movie movie)
        {
            repo.Update(movie);
            repo.Save();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            return View(repo.GetById(id));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            repo.Delete(id);
            repo.Save();
            return RedirectToAction("Index");
        }

        public ActionResult ByYear(int year)
        {
            return View(repo.GetByYear(year));
        }

        public ActionResult ByDirector(string name)
        {
            return View(repo.GetByDirector(name));
        }
    }
}