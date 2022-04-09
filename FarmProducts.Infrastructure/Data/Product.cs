using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        
        [Range(0,10000.00)]
        [Column(TypeName = "Money")]
        public decimal Price { get; set; }
        
        [Required]
        public Category Category { get; set; }

        [ForeignKey("Farm")]
        public Guid FarmId { get; set; }
        
        [Required]
        public Farm Farm { get; set; }
        
        public ICollection<OrderProduct> Orders { get; set; } = new List<OrderProduct>();
    }
}
