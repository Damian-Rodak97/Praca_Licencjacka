using AdoptujZwierzaka.Data;
using System.Linq;

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
                    dbEntryPet.City = pet.City;
                }
            }
            context.SaveChanges();
        }
        public Pet DeletePet(Pet pet)
        {
            Pet dbEntryPet = context.Pets
                .FirstOrDefault(p => p.ID == pet.ID);
            if (dbEntryPet != null)
            {
                context.Pets.Remove(dbEntryPet);
                context.SaveChanges();
            }
            return dbEntryPet;
        }
    }
}
