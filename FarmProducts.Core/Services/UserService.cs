using FarmProducts.Core.Contracts;
using FarmProducts.Core.Models;
using FarmProducts.Infrastructure.Data.Identity;
using FarmProducts.Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmProducts.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IApplicationDbRepository repo;
        private readonly UserManager<User> manager;
        public UserService(IApplicationDbRepository _repo,UserManager<User> _manager)
        {
            repo= _repo;
            manager= _manager;
        }
        public async Task<UserViewModel> GetUser()
        {
            var user = "p";

            return new UserViewModel() { Id = user };

        }
    }
}
