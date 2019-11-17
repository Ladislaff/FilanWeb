using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FilanWeb.Models;

namespace FilanWeb.ViewModels
{
	public class RandomMovieViewModel
	{
		public Movie Movie { get; set; }
		public List<Costumer> Costumers { get; set; }
	}
}