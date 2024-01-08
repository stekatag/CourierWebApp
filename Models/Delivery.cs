using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CourierWebApp.Models
{
    public class Delivery : IEnumerable
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Choose a customer")]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        [Display(Name = "Choose an item")]
        public int ItemId { get; set; }
        public virtual Item Item { get; set; }

        [Display(Name = "Choose a unit")]
        public int UnitId { get; set; }
        public virtual Units Unit { get; set; }

        public int Quantity { get; set; }
        public double Price { get; set; }
        public DateTime Date { get; set; }

        public virtual ICollection<DeliveryItem> DeliveryItems { get; set; }

        public Delivery()
        {
            DeliveryItems = new HashSet<DeliveryItem>();
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
