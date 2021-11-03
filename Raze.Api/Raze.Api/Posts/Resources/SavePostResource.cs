using System.ComponentModel.DataAnnotations;

namespace Raze.Api.Resources
{
    public class SavePostResource
    {
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        
        [Required]
        public string Image { get; set; }
        
        [Required]
        [MaxLength(150)]
        public string Description { get; set; }
        
        [Required]
        public float Rate { get; set; }
        
        [Required]
        public int NumberOfRates { get; set; }
        
        [Required]
        public int UserId { get; set; }
        
        [Required]
        public int InterestId { get; set; }
    }
}