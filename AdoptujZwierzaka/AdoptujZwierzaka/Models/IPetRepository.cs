using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdoptujZwierzaka.Models
{
    public interface IPetRepository
    {
        IQueryable<Pet> Pets { get; }
        void SavePet(Pet pet);
    }
}
