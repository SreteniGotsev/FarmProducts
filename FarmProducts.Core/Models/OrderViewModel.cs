using FarmProducts.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmProducts.Core.Models
{
    public class OrderViewModel
    {
        public Guid Id { get; set; }
        public decimal TotalPrice { get; set; } 
        public Status Status { get; set;}
        public string DateCreated { get; set; }
    }
}
