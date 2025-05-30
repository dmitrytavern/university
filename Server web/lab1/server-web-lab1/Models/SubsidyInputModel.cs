using System.ComponentModel.DataAnnotations;

namespace server_web_lab1.Models
{
    public class SubsidyInputModel
    {
        [Required]
        [Range(1, 500)]
        public double ApartmentArea { get; set; }

        [Required]
        [Range(1, 20)]
        public int RoomCount { get; set; }

        [Required]
        [Range(1, 20)]
        public int ResidentsCount { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal TotalIncome { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal UtilityCosts { get; set; }

        public bool HasDisabled { get; set; }

        public bool HasChildren { get; set; }

        public bool HasUnemployed { get; set; }

        public decimal? SubsidyResult { get; set; }
    }
}
