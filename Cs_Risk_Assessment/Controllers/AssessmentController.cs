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
			if (!formData.Any())
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

							foreach (var vul in threat.Vulnerabilities)
							{

								var vulObj = formData[index];

								var newVul = new Vulnerability();
								newVul.vul = vulObj.Vulnerability;
								newVul.LikeliHood = vulObj.Likelihood;
								newVul.Impact = vulObj.Impact;
								newVul.ThreatId = newThreat.Id;

								newThreat.Vulnerabilities.Add(newVul);

								index++;

							}

							newAsset.Threats.Add(newThreat);
						}

						_context.Assets.Add(newAsset);

						try
						{
							await _context.SaveChangesAsync();
						}
						catch (Exception ex)
						{

							throw;
						}
					}


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
				.OrderByDescending(x => x.DateCreated)
				.Select(x => new AssessmentViewModel
				{
					Id = x.Id,
					Name = x.Name,
					AssetsCount = x.Assets.Count(),
				})
				.ToListAsync();
			return View(assessments.Any() ? assessments : new List<AssessmentViewModel>());
		}

		[HttpGet]
		public async Task<IActionResult> AssessmentDetails(Guid Id)
		{
			var user = await _userManager.GetUserAsync(User);

			if (user == null)
			{
				return NotFound();
			}
			var assessmentDetails = await _context.Assessments
				.Include(x => x.Assets)
					.ThenInclude(x => x.Threats)
						.ThenInclude(x => x.Vulnerabilities)
				.Where(x => x.UserId == user.Id && x.Id == Id)
				.FirstOrDefaultAsync();

			var response = new ViewAssessmentDetailsDto();

			var listOfVul = assessmentDetails.Assets.SelectMany(x => x.Threats.SelectMany(x => x.Vulnerabilities)).ToList();
			var ListofThreats = assessmentDetails.Assets.SelectMany(x => x.Threats).ToList();

			response.CriticalCount = listOfVul.Count(x => (Convert.ToInt32(x.LikeliHood) * Convert.ToInt32(x.Impact)) >= 20);
			response.HighCount = listOfVul.Count(x => (Convert.ToInt32(x.LikeliHood) * Convert.ToInt32(x.Impact)) >= 13 &&
			(Convert.ToInt32(x.LikeliHood) * Convert.ToInt32(x.Impact)) <= 19);
			response.ThreatsCount = ListofThreats.Count();


			var Top5Data = await _context.Assessments
											.Include(x => x.Assets)
												.ThenInclude(x => x.Threats)
													.ThenInclude(x => x.Vulnerabilities)
											.Where(x => x.UserId == user.Id)
											.ToListAsync();

			var top5Vul = Top5Data
									.SelectMany(x => x.Assets.SelectMany(x => x.Threats.SelectMany(x => x.Vulnerabilities)))
									.GroupBy(v => v.vul) // Group by vulnerability name
									.OrderByDescending(g => g.Count()) // Order by the count of each group in descending order
									.Take(5) // Take the top 5 groups
									.Select(g => new Top5Vul { name = g.Key, usage = g.Count() }) // Select the vulnerability name and count
									.ToList();

			var top5Threats = Top5Data
									.SelectMany(x => x.Assets.SelectMany(x => x.Threats))
									.GroupBy(threat => threat.Name) // Group by vulnerability name
									.OrderByDescending(g => g.Count()) // Order by the count of each group in descending order
									.Take(5) // Take the top 5 groups
									.Select(g => new Top5Threat { name = g.Key, usage = g.Count() }) // Select the vulnerability name and count
									.ToList();

			response.Top5Vuls = top5Vul;
			response.top5Threats = top5Threats;


			return View(response);
		}

		[HttpGet]
		public async Task<IActionResult> DetailRiskAssessment(Guid Id)
		{
			var assessmentDetails = await _context.Assessments
					.Include(x => x.Assets)
						.ThenInclude(x => x.Threats)
							.ThenInclude(x => x.Vulnerabilities)
					.Where(x => x.Id == Id)
					.FirstOrDefaultAsync();

			return View(assessmentDetails);
		}
		[HttpGet]
		public async Task<IActionResult> ControlRecomendations(Guid Id)
		{
			var assessmentDetails = await _context.Assessments
					.Include(x => x.Assets)
						.ThenInclude(x => x.Threats)
							.ThenInclude(x => x.Vulnerabilities)
					.Where(x => x.Id == Id)
					.FirstOrDefaultAsync();

			return View(assessmentDetails);
		}
	}


	
}
