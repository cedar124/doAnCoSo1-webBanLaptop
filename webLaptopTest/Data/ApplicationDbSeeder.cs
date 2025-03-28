using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webLaptopTest.Data.Static;
using webLaptopTest.Models;

namespace webLaptopTest.Data
{
    public class ApplicationDbSeeder
    {
        public static void Seed(IApplicationBuilder builder)
        {
            using (var serviceScope = builder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();

                //Category
                if (!context.Category.Any())
                {
                    context.Category.AddRange(new List<Category>()
                    {
                        new Category() {Name = "Gaming"},
                        new Category() {Name = "Van Phong"}
                    });
                    context.SaveChanges();
                }
                //Manufacturer
                if (!context.Manufacturer.Any())
                {
                    context.Manufacturer.AddRange(new List<Manufacturer>()
                    {
                        new Manufacturer() {Name = "Lenovo",},
                        new Manufacturer() {Name = "Asus",},
                    });
                    context.SaveChanges();
                }
                //Item
                if (!context.Item.Any())
                {
                    context.Item.AddRange(new List<Item>()
                    {
                        new Item()
                        {

                            Name = "Lenovo Gaming LOQ R7-7435HS - RTX 4050 6GB - 12GB RAM",
                            imgUrl = "https://cdn2.fptshop.com.vn/unsafe/750x0/filters:quality(100)/lenovo_loq_15arp9_2_5c25f47206.png",
                            imgUrl2 = "https://bizweb.dktcdn.net/100/362/971/products/screenshot-2024-07-16-183717.png?v=1721131292740",
                            Description = "Laptop Lenovo Gaming LOQ 15ARP9 R7-7435HS/12GB/512GB/15.6inches/FHD/RTX4050_6GB/Win11",
                            Price = 24890000,
                            Stock = 21,
                            ManufacturerId = 1,
                            CategoryId = 1
                        },
                        new Item()
                        {

                            Name = "Asus TUF Gaming i7 12700H - RTX4060 - 8GB RAM",
                            imgUrl = "https://cdn2.fptshop.com.vn/unsafe/750x0/filters:quality(100)/2023_7_4_638240754676290025_asus-tuf-gaming-fx507-xam-5.jpg",
                            imgUrl2 = "https://dlcdnwebimgs.asus.com/gain/475f1457-ebb7-46a2-a6ae-a63e2909efa8/w800",
                            Description = "Laptop Asus TUF Gaming FX507ZV4-LP041W i7 12700H/AI/8GB/512GB/15.6'/Nvidia RTX4060 8GB/Win11",
                            Price = 25499000,
                            Stock = 24,
                            ManufacturerId = 2,
                            CategoryId = 1
                        },
                        new Item()
                        {

                            Name = "ASUS Vivobook 14 OLED i5-12500H - 16GB RAM",
                            imgUrl = "https://cdn2.fptshop.com.vn/unsafe/750x0/filters:quality(100)/00908887_asus_vivobook_14_oled_a1405za_km263w_a82772e430.png",
                            imgUrl2 = "https://tramanh.vn/wp-content/uploads/2023/12/asus-vivobook-14-x1404va-4-768x768.jpg",
                            Description = "Laptop ASUS Vivobook 14 OLED A1405ZA-KM264W i5-12500H/16GB/512GB/14\" 2.8K/Win11",
                            Price = 15790000,
                            Stock = 24,
                            ManufacturerId = 2,
                            CategoryId = 2
                        }

                    });
                    context.SaveChanges();
                }
            }
        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder builder)
        {
            using (var serviceScope = builder.ApplicationServices.CreateScope())
            {
                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@webLaptop.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if(adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        Address = "",
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Admin@123?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }
            }
        }
    }
}
