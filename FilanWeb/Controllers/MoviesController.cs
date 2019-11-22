using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FilanWeb.Models;
using FilanWeb.ViewModels;
using System.Data.Entity;

namespace FilanWeb.Controllers
{
	public class MoviesController : Controller
	{
		private ApplicationDbContext _contex;

		public MoviesController()
		{
			_contex = new ApplicationDbContext();
		}

		protected override void Dispose(bool disposing)
		{
			_contex.Dispose();
		}

		// GET: Movies/Random
		public ViewResult Random()
		{
			var movie = _contex.Movies.Include(m => m.Genre).ToList();

			return View(movie);
		}

		public ViewResult New()
		{
			var genres = _contex.Genres.ToList();

			var viewModel = new NewMovieViewModel
			{
				Movie= new Movie(),
				Genres = genres
			};

			return View("NevMovie", viewModel);
		}

		public ActionResult Edit(int id)
		{
			var movie = _contex.Movies.SingleOrDefault(c => c.Id == id);

			if (movie == null)
				return HttpNotFound();

			var viewModel = new NewMovieViewModel
			{
				Movie = movie,
				Genres = _contex.Genres.ToList()
			};

			return View("NevMovie", viewModel);
		}

		public ActionResult DetailsMovie(int id)
		{
			var movie = _contex.Movies.SingleOrDefault(c => c.Id == id);

			if (movie == null)
				return HttpNotFound();

			return View(movie);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Save(Movie movie)
		{
			if (!ModelState.IsValid)
			{
				var viewModel = new NewMovieViewModel
				{
					Movie = movie,
					Genres = _contex.Genres.ToList()
				};
				return View("NevMovie", viewModel);
			}

			if (movie.Id == 0)
			{
				movie.DateAdded = DateTime.Now;
				_contex.Movies.Add(movie);
			}
			else
			{
				var movieInDb = _contex.Movies.Single(m => m.Id == movie.Id);
				movieInDb.Name = movie.Name;
				movieInDb.GenreId = movie.GenreId;
				movieInDb.NumberInStock = movie.NumberInStock;
				movieInDb.ReleaseDate = movie.ReleaseDate;
			}

			_contex.SaveChanges();

			return RedirectToAction("Random", "Movies");
		}
	}
}