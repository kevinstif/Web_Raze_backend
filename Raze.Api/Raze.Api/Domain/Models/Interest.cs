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
        
        public IList<AdvisorUser> UserAdvisors { get; set; } = new List<AdvisorUser>();
        public IList<AdvisedUser> UserAdviseds { get; set; } = new List<AdvisedUser>();
        public IList<Post> Posts { get; set; } = new List<Post>();
    }
}