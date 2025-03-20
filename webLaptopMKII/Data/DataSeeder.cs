using Microsoft.AspNetCore.Identity;
using webLaptopMKII.Constants;

namespace webLaptopMKII.Data
{
    public class DataSeeder
    {
        //them vai tro vao db
        public static async Task DefaultData(IServiceProvider service)
        {
            var userManager = service.GetService<UserManager<IdentityUser>>();
            var roleManager = service.GetService<RoleManager<IdentityRole>>();

            await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.User.ToString()));

            //tao admin mac dinh
            var admin = new IdentityUser
            {
                UserName = "admin@gmail.com", //have to be the same
                Email = "admin@gmail.com",
                EmailConfirmed = true
            };
            var adminInDb = await userManager.FindByEmailAsync(admin.Email);
            if(adminInDb is null)
            {
                await userManager.CreateAsync(admin, "Admin@123");
                await userManager.AddToRoleAsync(admin, Roles.Admin.ToString());
            }
        }
    }
}
