using FarmProducts.Infrastructure.Data.Identity;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmProducts.Infrastructure.Data
{
    public class Customer
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string Surname { get; set; }
        [Required]
        [MaxLength(150)]
        public string Address { get; set; }
        [MaxLength(11)]
        [MinLength(9)]
        public string PhoneNumber { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }

        public Guid CardId { get; set; }
        public Cart? Cart { get; set; }
    }
}
