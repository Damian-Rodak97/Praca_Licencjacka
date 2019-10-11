using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdoptujZwierzaka.Models
{
    public class FakePetRepository /* :  IPetRepository */
    {
        public IQueryable<Pet> Pets => new List<Pet>
        {
            new Pet {Name = "Azor", Category = "Pies"},
            new Pet {Name = "Lexi", Category = "Kot"},
            new Pet {Name = "Bolt", Category = "Pies"},
            new Pet {Name = "Pinki", Category = "Pies"},

        }.AsQueryable<Pet>();
    }
}
