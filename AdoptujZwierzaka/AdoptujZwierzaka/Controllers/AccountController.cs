using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AdoptujZwierzaka.Models;
using AdoptujZwierzaka.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace AdoptujZwierzaka.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private IPetRepository repository;
        private IHostingEnvironment hostingEnvironment;
        private readonly UserManager<IdentityUser> userManager;
        public int PageBigSize = 16;

        public AccountController(IPetRepository repository, IHostingEnvironment hostingEnvironment, UserManager<IdentityUser> userManager)
        {
            this.repository = repository;
            this.hostingEnvironment = hostingEnvironment;
            this.userManager = userManager;
        }

        public ViewResult Index(string city, string category, int petPage = 1)
        {
            var userId = userManager.GetUserId(HttpContext.User);
            var currentUserPets = repository.Pets.Where(x => x.User.Id == userId);

            var Pets = new PetsListViewModel
            {
                Pets = currentUserPets,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = petPage,
                    ItemsPerPage = PageBigSize,
                    TotalItems = category == null
                        ? repository.Pets.Count()
                        : repository.Pets.Where(e => e.Category == category).Count()
                },
                CurrentCategory = category
            };
                return View(Pets);
        }
        //{
        //   var userId = userManager.GetUserId(HttpContext.User);
        //    var currentUserPets = repository.Pets.Where(x => x.User.Id == userId);
        //    return View(currentUserPets);
        //  }
        public ViewResult Edit(int petId)
        {
            var userId = userManager.GetUserId(HttpContext.User);
            Pet pet = repository.Pets.FirstOrDefault(p => p.Id == petId && p.User.Id == userId);
            PetViewModel petViewModel = new PetViewModel
            {
                ID = pet.Id,
                AddDate = pet.AddDate,
                Category = pet.Category,
                City = pet.City,
                Description = pet.Description,
                Name = pet.Name,
                Photo = null,
                Sex = pet.Sex,
                Activity = pet.Activity,
                Size = pet.Size,
                Age = pet.Age
            };
            return View(petViewModel);
        } 
        [HttpPost]
        public IActionResult Edit(PetViewModel petViewModel)
        {
            var userId = userManager.GetUserId(HttpContext.User);
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (petViewModel.Photo != null)
                {
                   string uploadFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                   uniqueFileName = Guid.NewGuid().ToString() + "_" + petViewModel.Photo.FileName;
                   string filePath = Path.Combine(uploadFolder, uniqueFileName);
                   petViewModel.Photo.CopyTo(new FileStream(filePath,FileMode.Create));
                }
                Pet pet = new Pet
                {
                    UserId = userId,
                    Id = petViewModel.ID,
                    AddDate = DateTime.Now,
                    Category = petViewModel.Category,
                    City = petViewModel.City,
                    Description = petViewModel.Description,
                    Name = petViewModel.Name,
                    Picture = uniqueFileName,
                    Sex = petViewModel.Sex,
                    Activity = petViewModel.Activity,
                    Size = petViewModel.Size,
                    Age = petViewModel.Age
                };
                repository.SavePet(pet);
                TempData["message"] = $"Zapisano {pet.Name}."; 
                return RedirectToAction("Index"); }
            else
            { 
                // Błąd w wartościach danych.
                 return View(petViewModel);
            }
        }

        public ViewResult Create() => View("Edit", new PetViewModel());

        [HttpPost] 
        public IActionResult Delete(Pet pet) 
        { 
            Pet deletedPet = repository.DeletePet(pet);
            if (deletedPet != null)
            {
                TempData["message"] = $"Usunięto {deletedPet.Name}.";
            }
           
            return RedirectToAction("Index");
        }
        public ViewResult PetDetails(int petId)
        {
            ShelterModel shelter = new ShelterModel();
            shelter.Pet = repository.Pets.FirstOrDefault(p => p.Id == petId);
            var user = userManager.Users.FirstOrDefault(s => s.Id == shelter.Pet.UserId);
            shelter.User = user;
            return View("~/Views/Pet/PetDetails.cshtml", shelter);
        }
    }
}
