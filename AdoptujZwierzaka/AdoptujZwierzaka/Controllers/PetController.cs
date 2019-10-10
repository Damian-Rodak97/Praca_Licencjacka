using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdoptujZwierzaka.Models;
using Microsoft.AspNetCore.Mvc;
using AdoptujZwierzaka.Models.ViewModels;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdoptujZwierzaka.Controllers
{
    public class PetController : Controller
    {
        private IPetRepository repository;
        public int PageSize = 4;
        public PetController(IPetRepository repo)
        {
            repository = repo;
        }

        public ViewResult List(string category, int petPage = 1) 
            => View(new PetsListViewModel
        {
            Pets = repository.Pets
                .Where(p=> category == null || p.Category == category)
                .OrderBy(p => p.ID)
                .Skip((petPage - 1) * PageSize)
                .Take(PageSize),
            PagingInfo = new PagingInfo
            {
                CurrentPage = petPage,
                ItemsPerPage = PageSize,
                TotalItems = category == null ? repository.Pets.Count() : repository.Pets.Where(e => e.Category == category).Count()
            },
            CurrentCategory = category
        });
    }
}
