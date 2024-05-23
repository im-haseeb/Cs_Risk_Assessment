using Cs_Risk_Assessment.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.SqlServer.Server;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cs_Risk_Assessment.Controllers
{
	public class AssessmentController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult Step2()
		{
			// Retrieve the data from session
			string formDataJson = HttpContext.Session.GetString("Step2Data");

			if (!string.IsNullOrEmpty(formDataJson))
			{
				List<AssetsViewModel> formData = JsonConvert.DeserializeObject<List<AssetsViewModel>>(formDataJson);

				return View(formData);
			}
			else
			{
				// If session data is empty or data is not present, handle accordingly
				// For example, redirect to an error view
				return RedirectToAction("Error");
			}
		}

		[HttpPost]
		public IActionResult ProcessStep1([FromBody] List<AssetsViewModel> formData)
		{
			if(!formData.Any())
			{
				return BadRequest("No form data provided."); // 400 Bad Request
			}
			HttpContext.Session.SetString("Step2Data", JsonConvert.SerializeObject(formData));
			return Ok(); // 200 OK
		}

		[HttpPost]
		public IActionResult ProcessStep2([FromBody] List<AssetsViewModelWithThreats> formData)
		{
			return Json(formData);
			if (!formData.Any())
			{
				return BadRequest("No form data provided."); // 400 Bad Request
			}
			HttpContext.Session.SetString("Step2Data", JsonConvert.SerializeObject(formData));
			return Ok(); // 200 OK
		}
	}

}
