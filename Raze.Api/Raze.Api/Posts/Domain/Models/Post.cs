using System.Collections.Generic;
using Raze.Api.Security.Domain.Models;

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
        public int UserId { get; set; }
        public int InterestId { get; set; }
        public int TagId { get; set; }
        public User User { get; set; }
        public Interest Interest { get; set; }
        public IList<Comment> Comments { get; set; } = new List<Comment>();
        public Tag Tag { get; set; }

        // 
        // public Interest Interest { get; set; }
        // public IList<Tag> Tags { get; set; } = new List<Tag>();
        
    }
}