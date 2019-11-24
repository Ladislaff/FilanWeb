using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FilanWeb.Models;
using FilanWeb.Dtos;
using AutoMapper;
using System.Data.Entity;



namespace FilanWeb.Controllers.Api
{
	public class MoviesController : ApiController
	{

		private ApplicationDbContext _context;

		public MoviesController()
		{
			_context = new ApplicationDbContext();

		}

		//GET /api/movies

		public IHttpActionResult GetMovies()
		{
			var movieDto= _context.Movies
				.Include(c => c.Genre)
				.ToList()
				.Select(Mapper.Map<Movie, MoviesDto>);

			return Ok(movieDto);
		}

		//GET /api/movies/1

		public IHttpActionResult GetMovies(int id)
		{
			var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
			if (movie == null)
			{
				return NotFound();
			}
			return Ok(Mapper.Map<Movie, MoviesDto>(movie));

		}

		//POST /api/movies
		[HttpPost]
		public IHttpActionResult CreateMovie(MoviesDto moviesDto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest();
			}

			var movie = Mapper.Map<MoviesDto, Movie>(moviesDto);
			_context.Movies.Add(movie);
			_context.SaveChanges();
			moviesDto.Id = movie.Id;

			return Created(new Uri(Request.RequestUri + "/" + movie.Id), moviesDto);
		}

		//PUT /api/movies/1
		[HttpPut]
		public void UpdateMovie(int id, MoviesDto moviesDto)
		{
			if (!ModelState.IsValid)
			{
				throw new HttpResponseException(HttpStatusCode.BadRequest);
			}

			var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);

			if (movieInDb == null)
			{
				throw new HttpResponseException(HttpStatusCode.NotFound);
			}
			Mapper.Map(moviesDto, movieInDb);

			_context.SaveChanges();

		}

		//DELETE /api/movies/1
		[HttpDelete]
		public void DeleteMovie(int id)
		{
			var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);

			if (movieInDb == null)
			{
				throw new HttpResponseException(HttpStatusCode.NotFound);
			}

			_context.Movies.Remove(movieInDb);
			_context.SaveChanges();
		}
	}
}