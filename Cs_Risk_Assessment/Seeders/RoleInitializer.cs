using Microsoft.AspNetCore.Identity;

namespace Cs_Risk_Assessment.Seeders
{
	public static class RoleInitializer
	{
		public static async Task InitializeAsync(RoleManager<IdentityRole> roleManager)
		{
			string[] roleNames = { "Admin", "User" };

			foreach (var roleName in roleNames)
			{
				var roleExists = await roleManager.RoleExistsAsync(roleName);
				if (!roleExists)
				{
					// Create the roles and seed them to the database
					var roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
					if (!roleResult.Succeeded)
					{
						// Handle role creation error if needed
					}
				}
			}
		}
	}
}
