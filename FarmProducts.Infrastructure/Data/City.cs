using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmProducts.Infrastructure.Data
{
    public class City
    {
        public int Id { get; set; }

        public CityEnum Name { get; set; }

        public ICollection<Farm> Farms { get; set; }=new List<Farm>();
    }
}
