using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace AdoptujZwierzaka.Models
{
    public class ShelterModel
    {
        public Pet Pet { get; set; }
        public IdentityUser User { get; set; }
    }
}
