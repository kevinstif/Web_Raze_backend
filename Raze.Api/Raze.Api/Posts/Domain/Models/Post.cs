using System.Collections.Generic;

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
        // public User User { get; set; }
        // public Interest Interest { get; set; }
        // public IList<Tag> Tags { get; set; } = new List<Tag>();
        // public IList<Comment> Comments { get; set; } = new List<Comment>();
    }
}