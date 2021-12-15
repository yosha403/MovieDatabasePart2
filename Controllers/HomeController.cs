using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieRegistration.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRegistration.Controllers
{
    public class HomeController : Controller
    {
        public MovieDAL MovieDB = new MovieDAL();

        public IActionResult Index()
        {

            List<Movie> movies = MovieDB.GetMovies();
            return View(movies);
        }
      
        public IActionResult Details(int id)
        {
            Movie m = MovieDB.GetMovie(id);
            return View(m);
        }
      
        public IActionResult Create(Movie m)
        {     
            if (ModelState.IsValid)
            {               
                MovieDB.CreateMovie(m);
                return RedirectToAction("Index", "Home");
            }
            else
            {               
                return View();
            }
        }
        public IActionResult Delete(int id)
        {
            Movie m = MovieDB.GetMovie(id);
            return View(m);
        }
        public IActionResult DeleteFromDb(int id)
        {
            MovieDB.DeleteMovie(id);
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Edit(int id)
        {
            Movie m = MovieDB.GetMovie(id);
            return View(m);
        }

        [HttpPost]
        public IActionResult Edit(Movie m)
        {
            MovieDB.UpdateMovie(m);
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
