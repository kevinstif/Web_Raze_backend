using System.ComponentModel.DataAnnotations;

namespace Raze.Api.Resources
{
    public class SaveInterestResource
    {
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Description { get; set; }
        
        [Required]
        public bool Published { get; set; }
        
        //User
    }
}