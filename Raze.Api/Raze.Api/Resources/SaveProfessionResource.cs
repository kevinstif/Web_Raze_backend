using System.ComponentModel.DataAnnotations;

namespace Raze.Api.Resources
{
    public class SaveProfessionResource
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}