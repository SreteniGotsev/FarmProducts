using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmProducts.Core.Models
{
    public class CustomerViewModel
    {
        public Guid Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength (50)]
        public string Surname { get; set; }
        [MaxLength(150)]
        public string Address { get; set; }
        [MaxLength(11)]
        [MinLength(9)]
        public string PhoneNumber { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string UserId { get; set; }
    }
}
