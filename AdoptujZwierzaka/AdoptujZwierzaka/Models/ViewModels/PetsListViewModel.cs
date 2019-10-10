using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdoptujZwierzaka.Models.ViewModels
{
    public class PetsListViewModel
    {
        public IEnumerable<Pet> Pets { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}
