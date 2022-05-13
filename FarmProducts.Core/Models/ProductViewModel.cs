using FarmProducts.Core.Models;
using FarmProducts.Infrastructure.Data;

namespace FarmProducts.Core.Models
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
        public ICollection<Cart> Carts { get; set; } = new List<Cart>();
    }
}
