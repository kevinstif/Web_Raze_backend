﻿using System.Collections.Generic;
using Raze.Api.Users.Domain.Models;

namespace Raze.Api.Domain.Models
{
    public class Profession
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public IList<UserAdvisor> UserAdvisors { get; set; } = new List<UserAdvisor>();
    }
}