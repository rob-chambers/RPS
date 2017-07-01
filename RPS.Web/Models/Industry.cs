using System.ComponentModel.DataAnnotations;

namespace RPS.Web.Models
{
    public class Industry
    {
        public int Id { get; set; }

        [Required]
        [StringLength(5, MinimumLength = 2, ErrorMessage = "The industry code must be between 2 and 5 characters in length.")]
        public string Code { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
