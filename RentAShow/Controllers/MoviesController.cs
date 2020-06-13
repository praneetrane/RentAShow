using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using RentAShow.Models;
using RentAShow.ViewModels;
using System.Data.Entity;
using System.Data;

namespace RentAShow.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _Context;

        public MoviesController()
        {
            _Context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _Context.Dispose();
        }
        // GET: /Movies/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Random()
        {
            Movie movie = new Movie() { ID = 1, Name = "Shrek!" };

            var customers = new List<Customer>{
                new Customer{Id=1, Name ="Alex"},
                new Customer{Id=2, Name="Matt"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }


        [Route("Movies/ByReleasedDate/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1, 12)}")]

        public ContentResult MovieByRealsedDate(int month, int year)
        {
            return Content(string.Format("Month {0} , Year{1}", month, year));
        }

        public ViewResult MovieList()
        {

            var movieList = _Context.Movies.Include(m => m.Genre).ToList();

            return View(movieList);
        }

        public ViewResult Details(int id)
        {
            var movie = _Context.Movies.Include(m => m.Genre).SingleOrDefault(x => x.ID == id);

            return View(movie);
        }

        public ViewResult New(Movie movie)
        {
            var genres = _Context.Genres.ToList();

            var viewModel = new MovieFormViewModel()
            {
                Genres = genres
            };
            return View("MovieForm", viewModel);
        }

        public ViewResult Edit(int id)
        {
            Movie movie = _Context.Movies.Single(m => m.ID == id);

            var viewModel = new MovieFormViewModel(movie)
            {
                Genres = _Context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewmodel = new MovieFormViewModel(movie)
                {
                    //Removed Movie object set line from here and passing movie object recieved from the parameter to the 
                    //MovieFormViewModel() constructor.
                    Genres = _Context.Genres.ToList()
                };

                return View("MovieForm", viewmodel);
            }
            if (movie.ID == 0)
            {
                movie.DateAdded = DateTime.Now;
                _Context.Movies.Add(movie);
            }
            else
            {
                var movieInDB = _Context.Movies.Single(m => m.ID == movie.ID);

                if (movieInDB != null)
                {
                    movieInDB.Name = movie.Name;
                    movieInDB.ReleaseDate = movie.ReleaseDate;
                    movieInDB.GenreId = movie.GenreId;
                    movieInDB.NumberInStock = movie.NumberInStock;
                }
            }
            _Context.SaveChanges();
            return RedirectToAction("MovieList", "Movies");
        }
    }
}