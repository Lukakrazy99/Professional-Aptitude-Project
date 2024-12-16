using CakeShop.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace CakeShop.Persistence
{
    public static class DbInitializer
    {
        public static void SeedDatabase(
            CakeShopDbContext context,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration)
        {
            System.Console.WriteLine("Seeding... - Start");

            var categorias = new List<Categoria>
            {
                new Categoria {Nome = "Aventura"},

                new Categoria {Nome = "Casual"},

                new Categoria {Nome = "Combate"},

                new Categoria {Nome = "Corridas"},

                new Categoria {Nome = "Desporto"},

                new Categoria {Nome = "Indie"},

                new Categoria {Nome = "MMO"},

                new Categoria {Nome = "RPG"},

                new Categoria {Nome = "Terror"}
            
            };
            if (!context.Categorias.Any() && !context.Jogos.Any())
            {
                context.Categorias.AddRange(categorias);
                context.SaveChanges();
            }
            var plataformas = new List<Plataforma>
            {
                new Plataforma {Nome = "XBox"},

                new Plataforma {Nome = "Playstation"},

                new Plataforma {Nome = "Computador"}

            };
            if (!context.Plataformas.Any() && !context.Jogos.Any())
            {
                context.Plataformas.AddRange(plataformas);
                context.SaveChanges();
            }
           

            IdentityUser usr = null;
            string userEmail = configuration["Admin:Email"] ?? "admin@admin.com";
            string userName = configuration["Admin:Username"] ?? "admin";
            string password = configuration["Admin:Password"] ?? "Passw@rd!123";

            if (!context.Users.Any())
            {
                usr = new IdentityUser
                {
                    Email = userEmail,
                    UserName = userName
                };
                userManager.CreateAsync(usr, password);
            }

            if (!context.UserRoles.Any())
            {
                roleManager.CreateAsync(new IdentityRole("Admin"));
                roleManager.CreateAsync(new IdentityRole("User"));
                roleManager.CreateAsync(new IdentityRole("Employee"));
            }
            if (usr == null)
            {
                usr = userManager.FindByEmailAsync(userEmail).Result;
            }
            //if (!userManager.IsInRoleAsync(usr, "Admin").Result)
            //{
            //    userManager.AddToRoleAsync(usr, "Admin");
            //}

            // Create other users

            context.SaveChanges();

            System.Console.WriteLine("Seeding... - End");
			


			
        }

    }
}