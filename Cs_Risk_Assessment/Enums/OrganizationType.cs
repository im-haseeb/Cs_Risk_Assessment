using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Cs_Risk_Assessment.Enums
{
	public enum OrganizationType
	{
		[Display(Name = "Financial")]
		Financial,
		[Display(Name = "HealthCare")]
		HealthCare,
		[Display(Name = "Retail")]
		Retail,
		[Display(Name = "Military")]
		Military,
		[Display(Name = "Government")]
		Government,
		[Display(Name = "Academia")]
		Academia
	}
}
