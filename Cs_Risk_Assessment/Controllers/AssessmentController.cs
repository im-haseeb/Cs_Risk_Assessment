using Microsoft.AspNetCore.Mvc;

namespace Cs_Risk_Assessment.Controllers
{
	public class AssessmentController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
