using System.ComponentModel.DataAnnotations;

namespace server_web_lab3.Models
{
    public class Property
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Тип нерухомості")]
        public string Type { get; set; }

        [Range(1, 100)]
        [Display(Name = "Кількість кімнат")]
        public int Rooms { get; set; }

        [Range(1, 100)]
        [Display(Name = "Етажність")]
        public int Floors { get; set; }

        [Required]
        [Display(Name = "Стан")]
        public string Condition { get; set; }

        [Range(1, 100000000)]
        [Display(Name = "Оцінна вартість")]
        public decimal EstimatedValue { get; set; }
    }
}
