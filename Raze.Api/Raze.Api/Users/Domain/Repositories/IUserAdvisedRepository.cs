﻿using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Raze.Api.Users.Domain.Models;

namespace Raze.Api.Users.Domain.Repositories
{
    public interface IUserAdvisedRepository
    {
        Task<IEnumerable<UserAdvised>> ListAsync();
    }
}