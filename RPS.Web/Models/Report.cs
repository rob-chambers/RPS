using System.ComponentModel.DataAnnotations;

namespace RPS.Web.Models
{
    public class Report
    {
        public int Id { get; set; }

        [Required]
        public ReportCategory Category { get; set; }

        [Required]
        public int CountryId { get; set; }

        [Required]
        public Country Country { get; set; }

        public int? IndustryId { get; set; }

        public Industry Industry { get; set; }

        public int? SectorId { get; set; }

        public Sector Sector { get; set; }

        [Required]
        [StringLength(100)]
        [MinLength(10, ErrorMessage = "The title must be a minimum length of 10 characters.")]
        public string Title { get; set; }
    }
}
