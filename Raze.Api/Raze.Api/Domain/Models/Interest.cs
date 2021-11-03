using System.Collections.Generic;
using Raze.Api.Users.Domain.Models;

namespace Raze.Api.Domain.Models
{
    public class Interest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Published { get; set; }
        
        public IList<UserAdvisor> UserAdvisors { get; set; } = new List<UserAdvisor>();
        public IList<UserAdvised> UserAdviseds { get; set; } = new List<UserAdvised>();
        public IList<Post> Posts { get; set; } = new List<Post>();
    }
}