using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FilanWeb.Models;

namespace FilanWeb.ViewModels
{
	public class NewMovieViewModel
	{
		public IEnumerable<Genre> Genres { get; set; }
		public Movie Movie { get; set; }
	}
}