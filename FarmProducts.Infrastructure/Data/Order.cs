using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmProducts.Infrastructure.Data
{
    public class Order
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]

        [ForeignKey("Customer")]
        public Guid CustomerId { get; set; } 
        public Customer Customer { get; set; }
        [Required]
        [Column(TypeName = "Money")]
        public decimal TotalPrice { get; set; }
        [Required]
        public PaymentType PaymentType { get; set; }
        [Required]
        public Status Status { get; set; }

        public ICollection<OrderProduct> Products { get; set; } = new List<OrderProduct>();
    }
}
