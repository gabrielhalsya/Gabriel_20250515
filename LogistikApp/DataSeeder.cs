using LogistikApp.Models;
using Microsoft.AspNetCore.Identity;

namespace LogistikApp
{
    public static class DataSeeder
    {
        public static async Task SeedDefaultUserAsync(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            if (await userManager.FindByNameAsync("admin") == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "admin",
                    Email = "admin@example.com",
                    EmailConfirmed = true
                };

                await userManager.CreateAsync(user, "Admin123!");
            }
        }
    }
}
