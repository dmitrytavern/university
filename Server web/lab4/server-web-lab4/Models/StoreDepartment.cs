using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace server_web_lab4.Models
{
    public class StoreDepartment
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Department Name")]
        public string NAME { get; set; }

        public virtual ICollection<DepartmentProduct> DepartmentProducts { get; set; }

        public StoreDepartment()
        {
            DepartmentProducts = new HashSet<DepartmentProduct>();
        }
    }
}
