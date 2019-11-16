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
                                            },
                    new Pet
                    {
                        Name = "Inka",
                        Description = "Pies ma 3 lata i jest bardzo aktywna.",
                        Category = "Pies",
                        
                    },
                    new Pet
                    {
                        Name = "Perła",
                        Description = "Kotka ma 2 lata i jest bardzo aktywna.",
                        Category = "Kot",
                        
                    },
                    new Pet
                    {
                        Name = "Alex",
                        Description = "Pies ma 3 lata i jest bardzo aktywna.",
                        Category = "Pies",
                                            },
                    new Pet
                    {
                        Name = "Cezar",
                        Description = "Kot ma rok i jest bardzo leniwy.",
                        Category = "Kot",
                        
                    },
                    new Pet
                    {
                        Name = "Kropka",
                        Description = "Pies ma roczek i jest bardzo leniwy.",
                        Category = "Pies",
                        
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
