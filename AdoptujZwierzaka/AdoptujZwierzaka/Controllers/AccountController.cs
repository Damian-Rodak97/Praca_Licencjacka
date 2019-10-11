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
    }
}
