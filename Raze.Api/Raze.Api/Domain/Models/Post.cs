using System.Collections.Generic;
using Raze.Api.Users.Domain.Models;

namespace Raze.Api.Domain.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public float Rate { get; set; }
        public int NumberOfRates { get; set; }
        public string UserType { get; set; }
        public int UserId { get; set; }
        public UserAdvised UserAdvised { get; set; }
        public UserAdvisor UserAdvisor { get; set; }
        public int InterestId { get; set; }
        public Interest Interest { get; set; }
        public IList<Comment> Comments { get; set; } = new List<Comment>();
        public int TagId { get; set; }
        public Tag Tag { get; set; }

        // 
        // public Interest Interest { get; set; }
        // public IList<Tag> Tags { get; set; } = new List<Tag>();
        
    }
}