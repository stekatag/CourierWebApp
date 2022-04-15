using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CourierWebApp.Models
{
    public class Units
    {
        [Key]
        public int? UnitId{ get; set; }

        [Required]
        [Display(Name = "Unit")]
        public string Unit { get; set; }

        public virtual ICollection<Delivery> Deliveries { get; set; }
    }
}
