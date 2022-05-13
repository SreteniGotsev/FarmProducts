using FarmProducts.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmProducts.Core.Models
{
    public class FarmViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string Certificate { get; set; }
        public bool IsRegistered { get; set; }
        public Guid FarmerId { get; set; }
        public string Phone { get; set; }
        public ICollection<City> Cities { get; set; } = new List<City>();
        public ICollection<Product> Products { get; set; } = new List<Product>();
        public ICollection<Day> Days { get; set; } = new List<Day>();

    }
}
