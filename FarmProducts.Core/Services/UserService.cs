using FarmProducts.Core.Contracts;
using FarmProducts.Core.Models;
using FarmProducts.Infrastructure.Data.Identity;
using FarmProducts.Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FarmProducts.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IApplicationDbRepository repo;
        private readonly UserManager<User> manager;
        private readonly IHttpContextAccessor accessor;
        public UserService(IApplicationDbRepository _repo,UserManager<User> _manager, IHttpContextAccessor _accessor)
        {
            repo= _repo;
            manager= _manager;
            accessor = _accessor;
        }
        public string GetUserId()
        {
            var userId =  accessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return userId;

        }
    }
}
