using Cs_Risk_Assessment.Models;
using Cs_Risk_Assessment.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Cs_Risk_Assessment.Controllers
{
	[Authorize]
	public class ProfileController : Controller
	{
		private readonly UserManager<ApplicationUser> _userManager;
		public ProfileController(UserManager<ApplicationUser> userManager)
		{
			_userManager = userManager;
		}
		public async Task<IActionResult> Index()
		{
			// Retrieve the current user
			var user = await _userManager.GetUserAsync(User);
			if (user == null)
			{
				return NotFound();
			}

			// Pass the user data to the view
			return View(user);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> UpdateProfile([FromForm] ProfileViewModel model)
		{
			// Retrieve the current user
			var user = await _userManager.GetUserAsync(User);
			if (user == null)
			{
				return NotFound();
			}

			// Update the user's FullName
			user.FullName = model.FullName;
			user.OrganizationName = model.OrganizationName;
			user.OrganizationType = model.OrganizationType;
			user.Country = model.Country;
			var result = await _userManager.UpdateAsync(user);
			if (result.Succeeded)
			{
				// Update the custom claim with the new FullName
				var existingClaims = (await _userManager.GetClaimsAsync(user)).Where(c => c.Type == "LoggedInUserName").ToList();
				if (existingClaims.Any())
				{
					await _userManager.RemoveClaimsAsync(user, existingClaims);
					var customClaim = new Claim("LoggedInUserName", user.FullName);
					await _userManager.AddClaimAsync(user, customClaim);
				}
				// Return a success message
				return Json(new { success = true, message = "Profile updated successfully." });
			}
			else
			{
				// If update fails, return an error message
				var errorMessage = string.Join("\n", result.Errors.Select(e => e.Description));
				return Json(new { success = false, message = errorMessage });
			}
		}
	}
}
