using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdoptujZwierzaka.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic;

namespace AdoptujZwierzaka.Models
{
    public static class SeedData
    {
        public static void EnsurePetsOperation(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
            if (!context.Pets.Any())
            {
                context.Pets.AddRange(
                    new Pet
                    {
                        Name="Azor",
                        Description = "Pies ma 6 lat i jest bardzo aktywny.",
                        Category = "Pies",
                        AddDate = DateTime.Parse("06/21/2017 17:22:16")
                    },
                    new Pet
                    {
                        Name = "Inka",
                        Description = "Pies ma 3 lata i jest bardzo aktywna.",
                        Category = "Pies",
                        AddDate = DateTime.Parse("08/18/2018 12:12:14")
                    },
                    new Pet
                    {
                        Name = "Perła",
                        Description = "Kotka ma 2 lata i jest bardzo aktywna.",
                        Category = "Kot",
                        AddDate = DateTime.Parse("12/30/2011 09:33:26")
                    },
                    new Pet
                    {
                        Name = "Alex",
                        Description = "Pies ma 3 lata i jest bardzo aktywna.",
                        Category = "Pies",
                        AddDate = DateTime.Parse("01/13/2015 19:32:14")
                    },
                    new Pet
                    {
                        Name = "Cezar",
                        Description = "Kot ma rok i jest bardzo leniwy.",
                        Category = "Kot",
                        AddDate = DateTime.Parse("03/12/2014 02:13:14")
                    },
                    new Pet
                    {
                        Name = "Kropka",
                        Description = "Pies ma roczek i jest bardzo leniwy.",
                        Category = "Pies",
                        AddDate = DateTime.Parse("06/28/2017 13:12:13")
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
