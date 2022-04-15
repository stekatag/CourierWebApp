using System;
using System.ComponentModel.DataAnnotations;

namespace CourierWebApp.Models
{
    public class Delivery
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Units Unit { get; set; }

        public enum Units
        {
            [Display(Name = "Qty")] Quantity,
            [Display(Name = "kg")] Kilogram,
            [Display(Name = "L")] Litre,
            [Display(Name = "m")] Meter
        }
        public decimal Price { get; set; }
        public string Courier { get; set; }
        public DateTime Date { get; set; }

        public Delivery()
        {
            
        }
    }
}
