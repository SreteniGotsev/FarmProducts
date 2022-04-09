using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmProducts.Infrastructure.Data
{
    public class Farm
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public string  Address { get; set; }
        [Required]
        [MaxLength(100)]
        public string Description { get; set; }

        public string Certificate { get; set; }

        public bool IsRegistered { get; set; }

        [Required]
        public Guid FarmerId { get; set; }
        public Farmer Farmer { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();


        public ICollection<City> Cities { get; set; } = new List<City>();

        public ICollection<Day> DeliveryDays { get; set; } = new List<Day>();
    }
}
