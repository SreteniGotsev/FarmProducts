using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmProducts.Infrastructure.Data
{
    public class Farmer: IdentityUser
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string Surname { get; set; }
        [Required]
        [MaxLength(150)]
        public string Address { get; set; }
      
        public ICollection<Farm> Farms { get; set; }=new List<Farm>();
    }
}
