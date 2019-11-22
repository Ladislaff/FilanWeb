using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FilanWeb.Models;

namespace FilanWeb.ViewModels
{
	public class NewCostumerViewModel
	{
		public IEnumerable<MembershipType> MembershipTypes { get; set; }
		public Costumer Costumer { get; set; }
	}
}