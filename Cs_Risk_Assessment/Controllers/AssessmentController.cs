using Cs_Risk_Assessment.Models;
using Cs_Risk_Assessment.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cs_Risk_Assessment.Controllers
{
	[Authorize]
	public class AssessmentController : Controller
	{
		private readonly ApplicationDbContext _context;
		private readonly UserManager<ApplicationUser> _userManager;
		public AssessmentController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
		{
			_context = context;
			_userManager = userManager;
		}
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

		public IActionResult Step3()
		{
			// Retrieve the data from session
			string formDataJson = HttpContext.Session.GetString("Step3Data");

			if (!string.IsNullOrEmpty(formDataJson))
			{
				List<AssetsViewModelWithThreats> formData = JsonConvert.DeserializeObject<List<AssetsViewModelWithThreats>>(formDataJson);

				return View(formData);
			}
			else
			{
				// If session data is empty or data is not present, handle accordingly
				// For example, redirect to an error view
				return RedirectToAction("Error");
			}
		}

		public IActionResult Step4()
		{
			// Retrieve the data from session
			string formDataJson = HttpContext.Session.GetString("Step4Data");

			if (!string.IsNullOrEmpty(formDataJson))
			{
				List<AssetsViewModelWithThreatsAndVulnerabilities> formData = JsonConvert.DeserializeObject<List<AssetsViewModelWithThreatsAndVulnerabilities>>(formDataJson);

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
			formData = formData.Where(asset => asset != null && asset.AssetName != "").ToList();
			HttpContext.Session.SetString("Step2Data", JsonConvert.SerializeObject(formData));
			return Ok(); // 200 OK
		}

		[HttpPost]
		public IActionResult ProcessStep2([FromBody] List<AssetsViewModelWithThreats> formData)
		{
			//return Json(formData);
			if (!formData.Any())
			{
				return BadRequest("No form data provided."); // 400 Bad Request
			}
			formData = formData.Where(asset => asset != null && asset.AssetName != "").ToList();
			HttpContext.Session.SetString("Step3Data", JsonConvert.SerializeObject(formData));
			return Ok(); // 200 OK
		}

        [HttpPost]
        public async Task<IActionResult> ProcessStep3([FromBody] List<AssetsViewModelWithThreatsAndVulnerabilities> formData)
        {
			if (!formData.Any())
			{
				return BadRequest("No form data provided."); // 400 Bad Request
			}
			formData = formData.Where(asset => asset != null && asset.AssetName != "").ToList();
			HttpContext.Session.SetString("Step4Data", JsonConvert.SerializeObject(formData));
			return Ok(); // 200 OK
		}

		[HttpPost]
		public async Task<IActionResult> ProcessStep4([FromBody] List<LikehoodAndImpactDto> formData)
		{
			if (!formData.Any())
			{
				return BadRequest("No form data provided."); // 400 Bad Request
			}
			//formData = formData.Where(asset => asset != null && asset.AssetName != "").ToList();
			//HttpContext.Session.SetString("Step4Data", JsonConvert.SerializeObject(formData));
			//return Ok(); // 200 OK

			string sessionDataJson = HttpContext.Session.GetString("Step4Data");

			if (!string.IsNullOrEmpty(sessionDataJson))
			{
				List<AssetsViewModelWithThreatsAndVulnerabilities> sessionData = JsonConvert.DeserializeObject<List<AssetsViewModelWithThreatsAndVulnerabilities>>(sessionDataJson);

				var user = await _userManager.GetUserAsync(User);
				if (user == null)
				{
					return NotFound();
				}

				// Filter out empty objects
				sessionData = sessionData.Where(asset => asset != null && asset.AssetName != "").ToList();

				if (sessionData.Any())
				{
					var newAssessment = new Assessment
					{
						// Generate a readable name using the current date and time
						Name = "Assessment_" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"),
						UserId = user.Id,
					};

					_context.Assessments.Add(newAssessment);


					int index = 0;
					foreach (var asset in sessionData)
					{
						var newAsset = new Asset();
						newAsset.Name = asset.AssetName;
						newAsset.Type = asset.AssetType;
						newAsset.Reference = asset.Reference;
						newAsset.Location = asset.Location;
						newAsset.Owner = asset.Owner;
						newAsset.AssessmentId = newAssessment.Id;

						
						foreach (var threat in asset.Threats)
						{
							var newThreat = new Threat();
							newThreat.Name = threat.Threat;
							newThreat.AssetId = newAsset.Id;

							foreach(var vul in threat.Vulnerabilities)
							{
								index++;
								var vulObj = formData[index];

								var newVul = new Vulnerability();
								newVul.vul = vulObj.Vulnerability;
								newVul.LikeliHood = vulObj.Likelihood;
								newVul.Impact = vulObj.Impact;
								newVul.ThreatId = newThreat.Id;

								_context.Vulnerabilities.Add(newVul);

							}

							newAsset.Threats.Add(newThreat);
						}

						_context.Assets.Add(newAsset);
					}

					await _context.SaveChangesAsync();
				}
				return Json(new { success = true, message = "Assessment created successfully." });
			}
			else
			{
				// If session data is empty or data is not present, handle accordingly
				// For example, redirect to an error view
				return RedirectToAction("Error");
			}

		}

		[HttpGet]
		public async Task<IActionResult> ViewAllAssessments()
		{
			var user = await _userManager.GetUserAsync(User);
			if (user == null)
			{
				return NotFound();
			}
			var assessments = await _context.Assessments
				.Where(x => x.UserId == user.Id)
				.OrderByDescending(x=> x.DateCreated)
				.Select(x=> new AssessmentViewModel
				{
					Name = x.Name,
					AssetsCount = x.Assets.Count(),
				})
				.ToListAsync();
			return View(assessments.Any() ? assessments : new List<AssessmentViewModel>());
		}
	}

}
