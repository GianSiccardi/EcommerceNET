using Application.Models.Authorization;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Role = Application.Models.Authorization.Role;

namespace Infrastructure.Persistencia
{
     public  class EcommerceDbContextData
    {

        public static async Task LoadDataAsync(
            EcommerceDbContext context , 
            UserManager<Usuario>usuarioManager,
            RoleManager<IdentityRole>roleManager,
            ILoggerFactory loggerFactory

            )
        {
            try
            {
                if (roleManager.Roles.Any())
                {
                    await roleManager.CreateAsync(new IdentityRole(Role.ADMIN));
                    await roleManager.CreateAsync(new IdentityRole(Role.USER));
                }
                if (!usuarioManager.Users.Any())
                {
                    var usuarioAdmin = new Usuario
                    {
                        Name="Gian",
                        LastName="Siccardi",
                        Email="giansicca@gmail.com",
                        UserName="Gian",
                        PhoneNumber="123456789",
                        AvatarUrl="avatar"

                    };

                    await usuarioManager.CreateAsync(usuarioAdmin, "123456789");
                    await usuarioManager.AddToRoleAsync(usuarioAdmin, Role.ADMIN);


                    var usuario = new Usuario
                    {
                        Name = "Lucas",
                        LastName = "Fernandez",
                        Email = "lucas.fernandez@gmail.com",
                        UserName = "LucasF",
                        PhoneNumber = "987654321",
                        AvatarUrl = "profile_pic_lucas"
                    };

                    await usuarioManager.CreateAsync(usuario, "123456789");
                    await usuarioManager.AddToRoleAsync(usuario, Role.USER);


                }


                if (!context.Categories!.Any())
                {
                    var categoryData = File.ReadAllText("../Infrastructure/Data/category.json");
                    var categories = JsonConvert.DeserializeObject<List<Category>>(categoryData);
                    await context.Categories!.AddRangeAsync(categories!);
                    await context.SaveChangesAsync();
                }



                if (!context.Products!.Any())
                {
                    var productData = File.ReadAllText("../Infrastructure/Data/product.json");
                    var products = JsonConvert.DeserializeObject<List<Product>>(productData);
                    await context.Products!.AddRangeAsync(products!);
                    await context.SaveChangesAsync();
                }



                if (!context.Images!.Any())
                {
                    var imageData = File.ReadAllText("../Infrastructure/Data/image.json");
                    var images = JsonConvert.DeserializeObject<List<Image>>(imageData);
                    await context.Images!.AddRangeAsync(images!);
                    await context.SaveChangesAsync();
                }



                if (!context.Reviews!.Any())
                {
                    var reviewData = File.ReadAllText("../Infrastructure/Data/countries.json");
                    var review = JsonConvert.DeserializeObject<List<Review>>(reviewData);
                    await context.Reviews!.AddRangeAsync(review!);
                    await context.SaveChangesAsync();
                }

                if (!context.Countries!.Any())
                {
                    var countryData = File.ReadAllText("../Infrastructure/Data/countries.json");
                    var countries = JsonConvert.DeserializeObject<List<Country>>(countryData);
                    await context.Countries!.AddRangeAsync(countries!);
                    await context.SaveChangesAsync();
                }

            }
            catch (Exception e)
            {
                var logger = loggerFactory.CreateLogger<EcommerceDbContextData>();
                logger.LogError(e.Message);
            }

        }
    }
}
