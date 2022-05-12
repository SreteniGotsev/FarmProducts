using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmProducts.Infrastructure.Data
{
    public class CartItem
    {
        public Guid Id { get; set; }= Guid.NewGuid();
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public Guid CartId { get; set; }
        public Cart Cart { get; set; }
    }
}
