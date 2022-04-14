using FarmProducts.Core.Models;
using FarmProducts.Infrastructure.Data;

namespace FarmProducts.Models
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public decimal Price { get; set; }
        public Guid FarmId { get; set; }    
        public Farm Farm { get; set; }
        public ICollection<OrderProduct> Orders { get; set; } = new List<OrderProduct>();
    }
}
