using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmProducts.Infrastructure.Data
{
    public class Product
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        
        [MaxLength(225)]
        public string Description { get; set; }
        
        [Range(0,10000)]
        public decimal Price { get; set; }
        
        [Required]
        public Category Category { get; set; }

        public Guid FarmId { get; set; }
        
        [Required]
        public Farm Farm { get; set; }
        
        public ICollection<Order> orders { get; set; } = new List<Order>();
    }
}
