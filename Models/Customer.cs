using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CourierWebApp.Models
{
    public class Customer
    {
        [Key]
        public int? CustomerId { get; set; }

        [Required]
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }

        [Required]
        [Display(Name = "Customer Email")]
        public string CustomerEmail { get; set; }

        public ICollection<Delivery> Deliveries { get; set; }
    }
}
