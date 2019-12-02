using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

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
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Proszę określić Date Dodania.")]
        [Display(Name = "Data Dodania")]
        public DateTime AddDate { get; set; }
        [Required(ErrorMessage = "Proszę dodać zdjęcie.")]
        [Display(Name = "Zdjęcie")]
        public IFormFile Photo { get; set; }
    }
}
