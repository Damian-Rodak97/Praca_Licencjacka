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
    }
}
