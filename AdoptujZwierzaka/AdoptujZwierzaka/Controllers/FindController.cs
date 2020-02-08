using AdoptujZwierzaka.Models;
using AdoptujZwierzaka.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
namespace AdoptujZwierzaka.Controllers
{
    public class FindController : Controller
    {
        public int PageBigSize = 16;
        private IPetRepository repository;
        public int PageSize = 4;

        public FindController(IPetRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult Index(string city, string category, int petPage = 1)
            => View(new PetsListViewModel
            {
                Pets = repository.Pets
                    .Where(p => category == null || p.Category == category && city == null || p.City == city)
                    .OrderBy(p => p.Id)
                    .Skip((petPage - 1) * PageBigSize)
                    .Take(PageBigSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = petPage,
                    ItemsPerPage = PageBigSize,
                    TotalItems = category == null
                        ? repository.Pets.Count()
                        : repository.Pets.Where(e => e.Category == category).Count()
                },
                CurrentCategory = category
            });
        public IActionResult Filter(string city, string category,string activity ,bool sex, int petPage = 1)
            => View(new PetsListViewModel
            {
                Pets = repository.Pets
                    .Where(p => category == null || p.Category == category )
                    .Where(p => city == null || p.City == city)
                    .Where(p => p.Sex == sex)
                    .Where(p => category == null || p.Activity == activity)
                    .OrderBy(p => p.Id)
                    .Skip((petPage - 1) * PageBigSize)
                    .Take(PageBigSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = petPage,
                    ItemsPerPage = PageBigSize,
                    TotalItems = category == null
                        ? repository.Pets.Count()
                        : repository.Pets.Where(e => e.Category == category).Count()
                },
                CurrentCategory = category
            });
        public ViewResult PetDetails(int petId)
        {
            Pet pet = repository.Pets.FirstOrDefault(p => p.Id == petId);
            return View(pet);
        }
    }
}