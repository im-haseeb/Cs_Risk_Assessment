using Cs_Risk_Assessment.Enums;
using System.ComponentModel.DataAnnotations;

namespace Cs_Risk_Assessment.ViewModels
{
	public class RegisterViewModel
	{
		[Required]
		[Display(Name = "FullName")]
		public string FullName { get; set; }

		[Required]
		[EmailAddress]
		[Display(Name = "Email")]
		public string Email { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[Display(Name = "Password")]
		public string Password { get; set; }

		[DataType(DataType.Password)]
		[Display(Name = "Confirm password")]
		[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
		public string ConfirmPassword { get; set; }

		[Required]
		[Display(Name = "OrganizationName")]
		public string OrganizationName { get; set; }

		[Required]
		[Display(Name = "OrganizationType")]
		public OrganizationType OrganizationType { get; set; }
		
		[Required]
		[Display(Name = "Country")]
		public string Country { get; set; }
	}
}
