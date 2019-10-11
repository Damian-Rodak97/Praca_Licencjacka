using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdoptujZwierzaka.Data;

namespace AdoptujZwierzaka.Models
{
    public class EFPetRepository : IPetRepository
    {
        private ApplicationDbContext context;

        public EFPetRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Pet> Pets => context.Pets;

        public void SavePet(Pet pet)
        {
            if (pet.ID == 0)
            {
                context.Pets.Add(pet);
            }
            else
            {
                Pet dbEntryPet = context.Pets.FirstOrDefault(p => p.ID == pet.ID);
                if (dbEntryPet != null)
                {
                    dbEntryPet.Name = pet.Name;
                    dbEntryPet.Description = pet.Description;
                    dbEntryPet.AddDate = pet.AddDate;
                    dbEntryPet.Category = pet.Category;
                }
            }

            context.SaveChanges();
        }
    }
}
