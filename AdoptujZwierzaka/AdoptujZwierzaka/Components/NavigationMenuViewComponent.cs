using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdoptujZwierzaka.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdoptujZwierzaka.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IPetRepository repository;

        public NavigationMenuViewComponent(IPetRepository repo)
        {
            repository = repo;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(repository.Pets
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}
