using FarmProducts.Infrastructure.Data.Identity;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmProducts.Infrastructure.Data
{
    public class Farmer
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string Surname { get; set; }      

        public string UserId { get; set; }
        public User User { get; set; }
        public Farm Farm { get; set; }
    }
}
