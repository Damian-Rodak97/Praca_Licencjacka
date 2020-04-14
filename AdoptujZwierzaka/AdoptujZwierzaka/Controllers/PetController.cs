using AdoptujZwierzaka.Models;
using AdoptujZwierzaka.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Identity;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdoptujZwierzaka.Controllers
{
    public class PetController : Controller
    {
        private IPetRepository repository;
        private readonly UserManager<IdentityUser> userManager;
        public int PageSize = 4;
        
        public PetController(IPetRepository repo, UserManager<IdentityUser> _userManager)
        {
            userManager = _userManager;
            repository = repo;
        }


        public ViewResult List(string city, string category, int petPage = 1)
            => View(new PetsListViewModel
            {
                Pets = repository.Pets
                 .Where(p => category == null || p.Category == category && city == null || p.City == city)
                .OrderBy(p => p.Id)
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

        public ViewResult PetDetails(int petId)
        {
            ShelterModel shelter = new ShelterModel();
            shelter.Pet = repository.Pets.FirstOrDefault(p => p.Id == petId);
            var user = userManager.Users.FirstOrDefault(s => s.Id == shelter.Pet.UserId);
            shelter.User = user;
            return View(shelter);
        }
    }
}
