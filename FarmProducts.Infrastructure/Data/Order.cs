using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmProducts.Infrastructure.Data
{
    public class Order
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public Guid CustomerId { get; set; } 
        public Customer Customer { get; set; }
        [Required]
        public decimal TotalPrice { get; set; }
        [Required]
        public PaymentType PaymentType { get; set; }
        [Required]
        public Status Status { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
