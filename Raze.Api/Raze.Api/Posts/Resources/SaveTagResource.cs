using System.ComponentModel.DataAnnotations;

namespace Raze.Api.Resources
{
    public class SaveTagResource
    {
        [Required]
        [MaxLength (20)]
        public string Title { get; set; }
    }
}