using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FilanWeb.Models;
using FilanWeb.ViewModels;

namespace FilanWeb.Controllers
{
	public class CostumersController : Controller
	{

		private ApplicationDbContext _contex;

		public CostumersController()
		{
			_contex = new ApplicationDbContext();
		}

		protected override void Dispose(bool disposing)
		{
			_contex.Dispose();
		}

		public ActionResult New()
		{
			var membershipTypes = _contex.MembershipTypes.ToList();
			var viewModel = new NewCostumerViewModel
			{
				Costumer= new Costumer(),
				MembershipTypes = membershipTypes
			};

			return View(viewModel);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(Costumer costumer)
		{
			if (!ModelState.IsValid)
			{
				var viewModel = new NewCostumerViewModel
				{
					Costumer = costumer,
					MembershipTypes = _contex.MembershipTypes.ToList()
				};
				return View("New", viewModel);
			}
			if (costumer.Id == 0)
			{
			_contex.Costumers.Add(costumer);
			}
			else
			{
			var costumeInDb = _contex.Costumers.Single(C => C.Id == costumer.Id);
			costumeInDb.Name = costumer.Name;
			costumeInDb.Birthdate = costumer.Birthdate;
			costumeInDb.MembershipTypeId = costumer.MembershipTypeId;
			costumeInDb.IsSubsctibedToNewsletter = costumer.IsSubsctibedToNewsletter;

			}
			_contex.SaveChanges();
			return RedirectToAction("CostumerList", "Costumers");
		}
		// GET: Costumers
		public ViewResult CostumerList()
		{
			var costumer = _contex.Costumers.Include(c => c.MembershipType).ToList();

			return View(costumer);
		}
		public ActionResult Details(int id)
		{
			var customer = _contex.Costumers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

			if (customer == null)
				return HttpNotFound();

			return View(customer);
		}

		public ActionResult Edit(int id)
		{
			var costumer = _contex.Costumers.SingleOrDefault(c => c.Id == id);

			if (costumer == null)
			{
				return HttpNotFound();
			}
			var viewModel = new NewCostumerViewModel
			{
				Costumer = costumer,
				MembershipTypes = _contex.MembershipTypes.ToList()
			};

			return View("New", viewModel);

		}
    }
}