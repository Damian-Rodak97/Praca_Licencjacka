using System;
using AdoptujZwierzaka.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Microsoft.AspNetCore.Identity;

namespace AdoptujZwierzaka.Models
{
    public static class SeedData
    {
        public static void EnsurePetsOperation(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
           
            context.Database.Migrate();
            if (!context.Users.Any())
            {
                context.Users.AddRange(
                    new IdentityUser
                    {
                        Id = "acec25c2-4144-450d-a305-b466188be6d8",
                        UserName = "Schronisko dla zwierząt Bydgoszcz",
                        NormalizedUserName = "TESTOWE@WP.PL",
                        Email = "Testowe@wp.pl",
                        NormalizedEmail = "TESTOWE@WP.PL",
                        EmailConfirmed = true,
                        PasswordHash =
                            "AQAAAAEAACcQAAAAEJulr5ZneLR6W43nr9yL3rMW4tohHgi43ndN0GkT1GDYh8+Dl19aRBB+79+Eu9Skpg==",
                        SecurityStamp = "BVSQHATQ645CCE2LPUAVD5BNKOSPQ7HN",
                        ConcurrencyStamp = "1d524979-4454-47cf-bc4b-3267443ba6a6",
                        LockoutEnabled = true
                    },
                    new IdentityUser
                    {
                        Id = "409bf9f7-b454-468a-8fc4-21811eb96374",
                        UserName = "SchroniskoWroclaw",
                        NormalizedUserName = "DAMIAN.RODAK97A@GMAIL.COM",
                        Email = "damian.rodak97a@gmail.com",
                        NormalizedEmail = "DAMIAN.RODAK97A@GMAIL.COM",
                        EmailConfirmed = true,
                        PasswordHash =
                            "AQAAAAEAACcQAAAAEHu9DfOqEajhYLd884AE6PjaNxgmEhVnRmZ+kgTaD0DLhR7i9kM0tKHELv6iceAhxg==",
                        PhoneNumber = "973845332",
                        SecurityStamp = "NVFFV5HDLFLEGWRHOQUXKHT5SEYB3A5C",
                        ConcurrencyStamp = "cabb1bbc-bdac-43f8-9367-2ff0f2b652aa",
                        LockoutEnabled = true
                    }

                );
                context.SaveChanges();
            }
            if (!context.Pets.Any())
            {
                context.Pets.AddRange(
                    new Pet
                    {
                        UserId = "acec25c2-4144-450d-a305-b466188be6d8",
                        Name = "Azor",
                        Description = "Mój pies nazywa się Borys. Jest to duży pies rasy nowofunlad, który jest samcem. Jego maść jest brązowa.To najżadsze ubarwienie tej rasy psa.Borys lubi spacery a także jeśli rzuca mu się patyk.Jego ulubione miejsce do hasania to las na granicy Popielowa i Jankowic.Moj pies jest zwierzęciem bardzo wesołym. Dawno już przestał być szczeniakiem ale do dziś lubi bawić sie piłką. Gdy przychodzę ze szkoły radośnie mnie wita szczekając. Borysa zabieram wszędzie gdzie mogę.Jest moim wiernym towarzyszem. Gdy pada deszcz bardzo się smuce, ponieważ nie mogę z nim pobawić lub wyjść na spacer.Gdy jest ciepło uwielbia gdy naleję mu zimnej wody do miski aby się ochłodził.Moim zdaniem warto zawsze mieć u boku takiego przyjaciela.Nigdy Cię nie opuści i zawsze będzie wiernym towarzyszem zabaw.",
                        Category = "Pies",
                        City = "Wroclaw",
                        Picture = "dog1.jpg",
                        AddDate = new DateTime(2019, 3, 15, 21, 22, 22),
                        PostCode = "54-234",
                        Phone = "983934123",
                        Street = "Szybka",
                        Sex = true,
                        Activity = "Kanapowiec",
                        Size = "Duży",
                        Age = 3,
                        Status = true
                    },
                    new Pet
                    {
                        UserId = "acec25c2-4144-450d-a305-b466188be6d8",
                        Name = "Inka",
                        Description = "Pies ma 3 lata i jest bardzo aktywna.",
                        Category = "Pies",
                        City = "Szczecin",
                        Picture = "dog2.jpg",
                        AddDate = new DateTime(2018, 11, 11, 11, 11, 02),
                        PostCode = "54-234",
                        Phone = "983934123",
                        Street = "Szybka",
                        Sex = false,
                        Activity = "Kanapowiec",
                        Size = "Duży",
                        Age = 3,
                        Status = false
                    },
                    new Pet
                    {
                        UserId = "acec25c2-4144-450d-a305-b466188be6d8",
                        Name = "Perła",
                        Description = "Kotka ma 2 lata i jest bardzo aktywna.",
                        Category = "Kot",
                        City = "Bydgoszcz",
                        Picture = "cat1.jpg",
                        AddDate = new DateTime(2017, 9, 13, 23, 02, 12),
                        PostCode = "54-234",
                        Phone = "983934123",
                        Street = "Szybka",
                        Sex = true,
                        Activity = "Kanapowiec",
                        Size = "Duży",
                        Age = 3,
                        Status = false
                    },
                    new Pet
                    {
                        UserId = "acec25c2-4144-450d-a305-b466188be6d8",
                        Name = "Alex",
                        Description = "Pies ma 3 lata i jest bardzo aktywna.",
                        Category = "Pies",
                        City = "Gdynia",
                        Picture = "dog3.jpg",
                        AddDate = new DateTime(2019, 6, 13, 11, 32, 42),
                        PostCode = "54-234",
                        Phone = "983934123",
                        Street = "Szybka",
                        Sex = false,
                        Activity = "Kanapowiec",
                        Size = "Duży",
                        Age = 3,
                        Status = false
                    },
                    new Pet
                    {
                        UserId = "acec25c2-4144-450d-a305-b466188be6d8",
                        Name = "Cezar",
                        Description = "Kot ma rok i jest bardzo leniwy.",
                        Category = "Kot",
                        City = "Racibórz",
                        Picture = "cat2.jpg",
                        AddDate = new DateTime(2019, 12, 13, 21, 21, 12),
                        PostCode = "54-234",
                        Phone = "983934123",
                        Street = "Szybka",
                        Sex = true,
                        Activity = "Kanapowiec",
                        Size = "Duży",
                        Age = 3,
                        Status = false
                    },
                    new Pet
                    {
                        UserId = "409bf9f7-b454-468a-8fc4-21811eb96374",
                        Name = "Kropka",
                        Description = "Spokojna kotka.",
                        Category = "Kot",
                        City = "Warszawa",
                        Picture = "cat3.jpg",
                        AddDate = new DateTime(2019, 12, 31, 00, 21, 12),
                        PostCode = "54-234",
                        Phone = "983934123",
                        Street = "Szybka",
                        Sex = false,
                        Activity = "Kanapowiec",
                        Size = "Duży",
                        Age = 3,
                        Status = false
                    },
                    new Pet
                    {
                        UserId = "409bf9f7-b454-468a-8fc4-21811eb96374",
                        Name = "Leszek",
                        Description = "Kotka ma 2 lata i jest bardzo aktywna.",
                        Category = "Kot",
                        City = "Bydgoszcz",
                        Picture = "cat1.jpg",
                        AddDate = new DateTime(2019, 12, 13, 21, 21, 12),
                        PostCode = "54-234",
                        Phone = "983934123",
                        Street = "Szybka",
                        Sex = false,
                        Activity = "Kanapowiec",
                        Size = "Duży",
                        Age = 3,
                        Status = false
                    },
                    new Pet
                    {
                        UserId = "409bf9f7-b454-468a-8fc4-21811eb96374",
                        Name = "Ferdek",
                        Description = "Pies ma 3 lata i jest bardzo aktywna.",
                        Category = "Pies",
                        City = "Gdynia",
                        Picture = "dog1.jpg",
                        AddDate = new DateTime(2019, 12, 13, 21, 21, 12),
                        PostCode = "54-234",
                        Phone = "983934123",
                        Street = "Szybka",
                        Sex = false,
                        Activity = "Kanapowiec",
                        Size = "Duży",
                        Age = 3,
                        Status = false
                    },
                    new Pet
                    {
                        UserId = "409bf9f7-b454-468a-8fc4-21811eb96374",
                        Name = "Zorza",
                        Description = "Kot ma rok i jest bardzo leniwy.",
                        Category = "Kot",
                        City = "Racibórz",
                        Picture = "cat3.jpg",
                        AddDate = new DateTime(2019, 12, 13, 21, 21, 12),
                        PostCode = "54-234",
                        Phone = "983934123",
                        Street = "Szybka",
                        Sex = false,
                        Activity = "Kanapowiec",
                        Size = "Duży",
                        Age = 3,
                        Status = false
                    },
                    new Pet
                    {
                        UserId = "409bf9f7-b454-468a-8fc4-21811eb96374",
                        Name = "Piorun",
                        Description = "Pies ma roczek i jest bardzo leniwy.",
                        Category = "Pies",
                        City = "Warszawa",
                        Picture = "dog3.jpg",
                        AddDate = new DateTime(2019, 12, 13, 21, 21, 12),
                        PostCode = "54-234",
                        Phone = "983934123",
                        Street = "Szybka",
                        Sex = false,
                        Activity = "Kanapowiec",
                        Size = "Duży",
                        Age = 3,
                        Status = false
                    },
                    new Pet
                    {
                        UserId = "409bf9f7-b454-468a-8fc4-21811eb96374",
                        Name = "Zbyszek",
                        Description = "Kotka ma 2 lata i jest bardzo aktywna.",
                        Category = "Kot",
                        City = "Bydgoszcz",
                        Picture = "cat2.jpg",
                        AddDate = new DateTime(2019, 12, 13, 21, 21, 12),
                        PostCode = "54-234",
                        Phone = "983934123",
                        Street = "Szybka",
                        Sex = false,
                        Activity = "Kanapowiec",
                        Size = "Duży",
                        Age = 3,
                        Status = false
                    },
                    new Pet
                    {
                        UserId = "409bf9f7-b454-468a-8fc4-21811eb96374",
                        Name = "Wafel",
                        Description = "Pies ma 3 lata i jest bardzo aktywna.",
                        Category = "Pies",
                        City = "Gdynia",
                        Picture = "dog2.jpg",
                        AddDate = new DateTime(2019, 12, 13, 21, 21, 12),
                        PostCode = "54-234",
                        Phone = "983934123",
                        Street = "Szybka",
                        Sex = false,
                        Activity = "Kanapowiec",
                        Size = "Duży",
                        Age = 3,
                        Status = false
                    },
                    new Pet
                    {
                        UserId = "409bf9f7-b454-468a-8fc4-21811eb96374",
                        Name = "Kret",
                        Description = "Kot ma rok i jest bardzo leniwy.",
                        Category = "Kot",
                        City = "Racibórz",
                        Picture = "cat1.jpg",
                        AddDate = new DateTime(2019, 12, 13, 21, 21, 12),
                        PostCode = "54-234",
                        Phone = "983934123",
                        Street = "Szybka",
                        Sex = false,
                        Activity = "Kanapowiec",
                        Size = "Duży",
                        Age = 3,
                        Status = false
                    },
                    new Pet
                    {
                        UserId = "409bf9f7-b454-468a-8fc4-21811eb96374",
                        Name = "Eryk",
                        Description = "Pies ma roczek i jest bardzo leniwy.",
                        Category = "Pies",
                        City = "Warszawa",
                        Picture = "dog3.jpg",
                        AddDate = new DateTime(2019, 12, 13, 21, 21, 12),
                        PostCode = "54-234",
                        Phone = "983934123",
                        Street = "Szybka",
                        Sex = false,
                        Activity = "Kanapowiec",
                        Size = "Duży",
                        Age = 3,
                        Status = false
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
