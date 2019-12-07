using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace AdoptujZwierzaka.Models
{
    public class Pet
    {
        public IdentityUser User { get; set; }
        public string UserId { get; set; }
        public int Id { get; set; }
        [Required(ErrorMessage = "Proszę podać nazwę produktu.")]
        [Display(Name = "Nazwa")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Proszę podać opis.")]
        [Display(Name = "Opis")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Proszę podać miasto.")]
        [Display(Name = "Miasto")]
        public string City { get; set; }
        public string PostCode { get; set; }
        public string Street { get; set; }
        public string Phone { get; set; }
        public string Sex { get; set; }

        [Required(ErrorMessage = "Proszę określić kategorię.")]
        [Display(Name = "Kategoria")]
        public string Category { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Proszę określić Date Dodania.")]
        [Display(Name = "Data Dodania")]
        public DateTime AddDate { get; set; }
        [Required(ErrorMessage = "Proszę dodać zdjęcie.")]
        [Display(Name = "Zdjęcie")]
        public string Picture { get; set; }
    }
}
