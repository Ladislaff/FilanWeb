using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FilanWeb.Models;

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

        
    }
}