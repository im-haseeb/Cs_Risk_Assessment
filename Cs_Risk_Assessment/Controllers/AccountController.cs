using Cs_Risk_Assessment.Models;
using Cs_Risk_Assessment.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Cs_Risk_Assessment.Controllers
{
	public class AccountController : Controller
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;

		public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}

		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Login(LoginViewModel model)
		{
			if (ModelState.IsValid)
			{
				var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
				if (result.Succeeded)
				{
					await AddCustomClaims(model.Email);
					return RedirectToAction("Index", "Home");
				}
				ModelState.AddModelError(string.Empty, "Invalid login attempt.");
			}
			return View(model);
		}

		private async Task AddCustomClaims(string email)
		{
			var user = await _userManager.FindByEmailAsync(email);

			var existingClaim = (await _userManager.GetClaimsAsync(user)).FirstOrDefault(c => c.Type == "LoggedInUserName");
			if (existingClaim == null)
			{
				var customClaim = new Claim("LoggedInUserName", user.FullName);
				await _userManager.AddClaimAsync(user, customClaim);
			}
		}

		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Register(RegisterViewModel model)
		{
			//return Json(model);
			if (ModelState.IsValid)
			{
				var user = new ApplicationUser 
				{ 
					UserName = model.Email, 
					Email = model.Email, 
					FullName = model.FullName,
					OrganizationName = model.OrganizationName,
					OrganizationType = model.OrganizationType,
					Country = model.Country
				};
				var result = await _userManager.CreateAsync(user, model.Password);
				if (result.Succeeded)
				{
					var customClaim = new Claim("LoggedInUserName", user.FullName);
					await _userManager.AddClaimAsync(user, customClaim);

					await _userManager.AddToRoleAsync(user, "User");
					await _signInManager.SignInAsync(user, isPersistent: false);

					return RedirectToAction("Index", "Home");
				}
				foreach (var error in result.Errors)
				{
					ModelState.AddModelError(string.Empty, error.Description);
				}
			}
			return View(model);
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Logout()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("Index", "Home");
		}

	}
}
