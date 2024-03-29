﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FilanWeb.Models
{
	public class MembershipType
	{
		public byte Id { get; set; }
		[Required]
		public string Name { get; set; }
		public short SingUpFee { get; set; }
		public byte DurationInMonths { get; set; }
		public byte DiscountRate { get; set; }

	}
}