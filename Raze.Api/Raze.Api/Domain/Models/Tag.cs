using System.Collections.Generic;

namespace Raze.Api.Domain.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public IList<Post> Posts { get; set; } = new List<Post>();
    }
}