using Cs_Risk_Assessment.Enums;
using System.ComponentModel.DataAnnotations;

namespace Cs_Risk_Assessment.ViewModels
{
	public class ProfileViewModel
	{
		[Required]
		[Display(Name = "FullName")]
		public string FullName { get; set; }

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
