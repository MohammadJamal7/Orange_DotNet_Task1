using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Orange_Task1_Dashboard.Data // Use your actual namespace
{
	public static class SeedData
	{
		public static async Task Initialize(IServiceProvider serviceProvider)
		{
			// Get RoleManager and UserManager from the service provider
			var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
			var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

			// Ensure "Manager" role exists
			if (!await roleManager.RoleExistsAsync("Manager"))
			{
				await roleManager.CreateAsync(new IdentityRole("Manager"));
			}

			// Ensure "Employee" role exists
			if (!await roleManager.RoleExistsAsync("Employee"))
			{
				await roleManager.CreateAsync(new IdentityRole("Employee"));
			}

			// Optionally, create a default manager user
			var managerUser = await userManager.FindByEmailAsync("manager@company.com");
			if (managerUser == null)
			{
				managerUser = new IdentityUser { UserName = "mohammad@jamal.com", Email = "manager@company.com" };
				await userManager.CreateAsync(managerUser, "Mohammad@123");

				// Assign the "Manager" role to the default user
				await userManager.AddToRoleAsync(managerUser, "Manager");
			}
		}
	}
}
