using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CourierWebApp.Models
{
    public class Item
    {
        [Key]
        public int? ItemId { get; set; }

        [Required]
        [Display(Name = "Item Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Item Description")]
        public string Description { get; set; }

        public virtual ICollection<Delivery> Deliveries { get; set; }
    }
}
