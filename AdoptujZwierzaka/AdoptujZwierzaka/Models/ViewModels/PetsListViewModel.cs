using System.Collections.Generic;

namespace AdoptujZwierzaka.Models.ViewModels
{
    public class PetsListViewModel
    {
        public IEnumerable<Pet> Pets { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}
