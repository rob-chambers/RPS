using System.ComponentModel.DataAnnotations;

namespace RPS.Web.Models
{
    public class Sector
    {
        public int Id { get; set; }

        [Required]
        public int IndustryId { get; set; }

        [Required]
        public Industry Industry { get; set; }

        [Required]
        [StringLength(10)]
        public string Code { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
