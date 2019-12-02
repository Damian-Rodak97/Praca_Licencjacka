using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AdoptujZwierzaka.Models;
using AdoptujZwierzaka.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace AdoptujZwierzaka.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private IPetRepository repository;
        private IHostingEnvironment hostingEnvironment;

        public AccountController(IPetRepository repo, IHostingEnvironment hostingEnvironment)
        {
            repository = repo;
            this.hostingEnvironment = hostingEnvironment;
        }

        public ViewResult Index() => View(repository.Pets);

        public ViewResult Edit(int petId)
        {

            Pet pet = repository.Pets.FirstOrDefault(p => p.ID == petId);
            PetViewModel petViewModel = new PetViewModel
            {
                ID = pet.ID,
                AddDate = pet.AddDate,
                Category = pet.Category,
                City = pet.City,
                Description = pet.Description,
                Name = pet.Name,
                Photo = null
               
            };
            return View(petViewModel);
        } 
        [HttpPost]
        public IActionResult Edit(PetViewModel petViewModel)
        {
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
                    ID = petViewModel.ID,
                    AddDate = petViewModel.AddDate,
                    Category = petViewModel.Category,
                    City = petViewModel.City,
                    Description = petViewModel.Description,
                    Name = petViewModel.Name,
                    Picture = uniqueFileName
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
    }
}
