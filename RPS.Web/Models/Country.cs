using System.ComponentModel.DataAnnotations;

namespace RPS.Web.Models
{
    public class Country
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }
    }
}
