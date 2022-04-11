using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmProducts.Infrastructure.Data.Identity
{
    public class User:IdentityUser
    {
        public Farmer Farmer { get; set; }
        public Customer Customer { get; set; }
    }
}
