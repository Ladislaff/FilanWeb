using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using FilanWeb.Models;

namespace FilanWeb.Dtos
{
	public class CostumerDto
	{
		public int Id { get; set; }
		
		[Required]
		[StringLength(255)]
		public string Name { get; set; }

		public MembershipTypeDto MembershipType { get; set; }

		public bool IsSubsctibedToNewsletter { get; set; }
		
		public byte MembershipTypeId { get; set; }
		
		//[Min18YearsIfAMember]
		public DateTime? Birthdate { get; set; }
	}
}