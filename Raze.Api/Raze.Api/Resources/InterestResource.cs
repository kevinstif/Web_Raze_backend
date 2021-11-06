using Raze.Api.Domain.Models;

namespace Raze.Api.Resources
{
    public class InterestResource
    {
        public InterestResource Interest { get; set; } //add
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Published { get; set; }
    }
}