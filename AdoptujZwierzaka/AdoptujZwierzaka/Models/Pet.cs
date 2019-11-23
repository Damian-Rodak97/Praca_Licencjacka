using System;
using System.ComponentModel.DataAnnotations;

namespace AdoptujZwierzaka.Models
{
    public class Pet
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
        public string Picture { get; set; }
    }
}
