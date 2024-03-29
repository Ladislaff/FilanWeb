﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FilanWeb.Models
{
	public class Costumer
	{
		public int Id { get; set; }
		[Required]
		[StringLength(255)]
		public string Name { get; set; }
		public bool IsSubsctibedToNewsletter { get; set; }
		public MembershipType MembershipType { get; set; }
		[Display(Name = "Membership Type")]
		public byte MembershipTypeId { get; set; }
		[Display(Name = "Date of Birth")]
		[Min18YearsIfAMember]
		public DateTime? Birthdate { get; set; }

	}
}