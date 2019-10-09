using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdoptujZwierzaka.Models
{
    public class Pet
    {
        public int PetsID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        [DataType(DataType.Date)] 
        public DateTime AddDate { get; set; }
        public string Picture { get; set; }
    }
}
