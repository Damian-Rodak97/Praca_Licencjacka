using AdoptujZwierzaka.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using AdoptujZwierzaka.Migrations;
using Microsoft.AspNetCore.Identity;

namespace AdoptujZwierzaka.Models
{
    public static class SeedData
    {
        public static void EnsurePetsOperation(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            var user = new IdentityUser
            {
                Id = "acec25c2-4144-450d-a305-b466188be6d8",
                UserName = "Testowe@wp.pl",
                NormalizedUserName = "TESTOWE@WP.PL",
                Email = "Testowe@wp.pl",
                NormalizedEmail = "TESTOWE@WP.PL",
                EmailConfirmed = true,
                PasswordHash =
                    "AQAAAAEAACcQAAAAEJulr5ZneLR6W43nr9yL3rMW4tohHgi43ndN0GkT1GDYh8+Dl19aRBB+79+Eu9Skpg==",
                SecurityStamp = "BVSQHATQ645CCE2LPUAVD5BNKOSPQ7HN",
                ConcurrencyStamp = "1d524979-4454-47cf-bc4b-3267443ba6a6",
                LockoutEnabled = true
            };
            context.Database.Migrate();
            if (!context.Users.Any())
            {
                context.Users.AddRange(
                    user
                );
                context.SaveChanges();
            }
            if (!context.Pets.Any())
            {
                context.Pets.AddRange(
                    new Pet
                    {
                        User = user,
                        Name = "Azor",
                        Description = "Pies ma 6 lat i jest bardzo aktywny.",
                        Category = "Pies",
                        City = "Wroclaw",
                        Picture = "dog.jpg",
                    },
                    new Pet
                    {
                        User = user,
                        Name = "Inka",
                        Description = "Pies ma 3 lata i jest bardzo aktywna.",
                        Category = "Pies",
                        City = "Szczecin",
                        Picture = "dog.jpg"
                    },
                    new Pet
                    {
                        User = user,
                        Name = "Perła",
                        Description = "Kotka ma 2 lata i jest bardzo aktywna.",
                        Category = "Kot",
                        City = "Bydgoszcz",
                        Picture = "dog.jpg"
                    },
                    new Pet
                    {
                        User = user,
                        Name = "Alex",
                        Description = "Pies ma 3 lata i jest bardzo aktywna.",
                        Category = "Pies",
                        City = "Gdynia",
                        Picture = "dog.jpg"
                    },
                    new Pet
                    {
                        User = user,
                        Name = "Cezar",
                        Description = "Kot ma rok i jest bardzo leniwy.",
                        Category = "Kot",
                        City = "Racibórz",
                        Picture = "dog.jpg"
                    },
                    new Pet
                    {
                        User = user,
                        Name = "Kropka",
                        Description = "Pies ma roczek i jest bardzo leniwy.",
                        Category = "Pies",
                        City = "Warszawa",
                        Picture = "dog.jpg"
                    },
                    new Pet
                    {
                        Name = "Perła",
                        Description = "Kotka ma 2 lata i jest bardzo aktywna.",
                        Category = "Kot",
                        City = "Bydgoszcz",
                        Picture = "dog.jpg"
                    },
                    new Pet
                    {
                        Name = "Alex",
                        Description = "Pies ma 3 lata i jest bardzo aktywna.",
                        Category = "Pies",
                        City = "Gdynia",
                        Picture = "dog.jpg"
                    },
                    new Pet
                    {
                        Name = "Cezar",
                        Description = "Kot ma rok i jest bardzo leniwy.",
                        Category = "Kot",
                        City = "Racibórz",
                        Picture = "dog.jpg"
                    },
                    new Pet
                    {
                        Name = "Kropka",
                        Description = "Pies ma roczek i jest bardzo leniwy.",
                        Category = "Pies",
                        City = "Warszawa",
                        Picture = "dog.jpg"
                    },
                    new Pet
                    {
                        Name = "Perła",
                        Description = "Kotka ma 2 lata i jest bardzo aktywna.",
                        Category = "Kot",
                        City = "Bydgoszcz",
                        Picture = "dog.jpg"
                    },
                    new Pet
                    {
                        Name = "Alex",
                        Description = "Pies ma 3 lata i jest bardzo aktywna.",
                        Category = "Pies",
                        City = "Gdynia",
                        Picture = "dog.jpg"
                    },
                    new Pet
                    {
                        Name = "Cezar",
                        Description = "Kot ma rok i jest bardzo leniwy.",
                        Category = "Kot",
                        City = "Racibórz",
                        Picture = "dog.jpg"
                    },
                    new Pet
                    {
                        Name = "Kropka",
                        Description = "Pies ma roczek i jest bardzo leniwy.",
                        Category = "Pies",
                        City = "Warszawa",
                        Picture = "dog.jpg"
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
