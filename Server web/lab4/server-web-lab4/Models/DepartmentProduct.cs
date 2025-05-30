using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server_web_lab4.Models
{
    public class DepartmentProduct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_RES { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Product Name")]
        public string NAME_RES { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Price")]
        public decimal PRICE_RES { get; set; }

        [StringLength(50)]
        [Display(Name = "Shelf Life")]
        public string TERM_RES { get; set; }

        // Foreign Key to StoreDepartment
        [Required]
        [Display(Name = "Department")]
        public int DepartmentID { get; set; }

        [ValidateNever]
        [ForeignKey("DepartmentID")]
        public virtual StoreDepartment StoreDepartment { get; set; }
    }
}
