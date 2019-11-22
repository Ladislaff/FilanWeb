using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FilanWeb.Models
{
	public class Min18YearsIfAMember : ValidationAttribute
	{
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			var costumer = (Costumer)validationContext.ObjectInstance;
			if (costumer.MembershipTypeId == 0 || costumer.MembershipTypeId == 1)
				return ValidationResult.Success;

			if (costumer.Birthdate == null)
				return new ValidationResult("Birthdatr is required!");

			var age = DateTime.Today.Year - costumer.Birthdate.Value.Year;

			return (age >= 18) ? ValidationResult.Success : new ValidationResult("Customer shuld be at least 18 years old to go on membership");
			
			
		}
	}
}