using Cs_Risk_Assessment.Enums;
using Microsoft.AspNetCore.Identity;

namespace Cs_Risk_Assessment.Models
{
	public class ApplicationUser : IdentityUser
	{
		public string? FullName { get; set; }
		public string? OrganizationName { get; set; }
		public OrganizationType OrganizationType { get; set; }
		public string? Country { get; set; }
        public ICollection<Assessment>? Assessments { get; set; }
    }
}