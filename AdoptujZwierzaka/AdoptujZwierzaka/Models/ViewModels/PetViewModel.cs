using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AdoptujZwierzaka.Models.ViewModels
{
    public class PetViewModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Proszę podać nazwę produktu.")]
        [Display(Name = "Nazwa")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Proszę podać opis.")]
        [Display(Name = "Opis")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Proszę podać miasto.")]
        [Display(Name = "Miasto")]
        public string City { get; set; }


        [Required(ErrorMessage = "Proszę określić kategorię.")]
        [Display(Name = "Kategoria")]
        public string Category { get; set; }
        [Required(ErrorMessage = "Proszę określić płeć.")]
        [Display(Name = "Płeć")]
        public bool Sex { get; set; }
        [Required(ErrorMessage = "Proszę wybiać aktywność zwierzęcia.")]
        [Display(Name = "Aktywność")]
        public string Activity { get; set; }
        [Required(ErrorMessage = "Proszę wybiać wielkość zwierzęcia.")]
        [Display(Name = "Wielkość")]
        public string Size { get; set; }
        [Required(ErrorMessage = "Proszę podać wiek zwierzęcia.")]
        [Display(Name = "Wiek")]
        public int Age { get; set; }
        [DataType(DataType.Date)]
        public DateTime AddDate { get; set; }
        [Required(ErrorMessage = "Proszę dodać zdjęcie.")]
        [Display(Name = "Zdjęcie")]
        public IFormFile Photo { get; set; }
   
    }
}
