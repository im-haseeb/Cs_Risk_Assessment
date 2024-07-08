using Cs_Risk_Assessment.Models;
using Cs_Risk_Assessment.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Cs_Risk_Assessment.Controllers
{
	[Authorize]
	public class HomeController : Controller
	{
        private readonly ApplicationDbContext _context;
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(ILogger<HomeController> logger, UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _logger = logger;
            _userManager = userManager;
            _context = context;
        }

        public async Task<IActionResult> Index()
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
                .Where(x => x.UserId ==user.Id)
                .OrderByDescending(x=> x.DateCreated)
                .FirstOrDefaultAsync();
            if(assessmentDetails is null)
            {
                return View(new ViewAssessmentDetailsDto());
            }

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
            response.HasValue = true;

            return View(response);
        }

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}