﻿using FarmProducts.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmProducts.Core.Contracts
{
    public interface IUserService
    {
        Task<UserViewModel> GetUser();
    }
}
