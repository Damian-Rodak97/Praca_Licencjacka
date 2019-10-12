using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdoptujZwierzaka.Models;
using Microsoft.AspNetCore.Mvc;


namespace AdoptujZwierzaka.Controllers
{
    public class AccountController : Controller
    {
        private IPetRepository repository;

        public AccountController(IPetRepository repo)
        {
            repository = repo;

        }

        public ViewResult Index() => View(repository.Pets);

        public ViewResult Edit(int petId) => View(repository.Pets.FirstOrDefault(p => p.ID == petId));
        [HttpPost]
        public IActionResult Edit(Pet pet)
        {
            if (ModelState.IsValid) {
                repository.SavePet(pet);
                TempData["message"] = $"Zapisano {pet.Name}."; 
                return RedirectToAction("Index"); }
            else
            { 
                // Błąd w wartościach danych.
                 return View(pet);
            }
        }

        public ViewResult Create() => View("Edit", new Pet());

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
