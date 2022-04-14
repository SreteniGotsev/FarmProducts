using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmProducts.Infrastructure.Data.Identity
{
    public class User:IdentityUser
    {
    
        public Guid? FarmerId { get; set; }
        public Farmer Farmer { get; set; }
        
        public Guid? CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
